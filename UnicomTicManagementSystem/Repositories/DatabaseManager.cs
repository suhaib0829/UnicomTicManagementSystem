// In Repositories/DatabaseManager.cs

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;


namespace UnicomTicManagementSystem.Repositories
{
    /// <summary>
    /// Manages all interactions with the SQLite database.
    /// This class follows the Singleton pattern to ensure only one instance is ever created,
    /// preventing database file conflicts.
    /// </summary>
    public class DatabaseManager
    {
        // --- Singleton Pattern Implementation ---
        private static readonly Lazy<DatabaseManager> _instance = new Lazy<DatabaseManager>(() => new DatabaseManager());
        public static DatabaseManager Instance => _instance.Value;

        private readonly string _connectionString;
        private const string DbFileName = "unicomtic.db";

        // --- Private Constructor ---
        // This is called only once by the Lazy<T> instance when it's first accessed.
        private DatabaseManager()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            _connectionString = $"Data Source={dbPath};Version=3;";
            // Initialize the database schema and default data when the application starts.
            InitializeDatabaseAsync().Wait();
        }

        /// <summary>
        /// Gets a new connection object for the SQLite database.
        /// </summary>
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        #region Initialization
        /// <summary>
        /// Creates the database file and all required tables if they do not already exist.
        /// Also populates the database with initial data for testing (users, rooms).
        /// </summary>
        private async Task InitializeDatabaseAsync()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName)))
            {
                SQLiteConnection.CreateFile(DbFileName);
            }

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                // A single SQL command to create all tables for efficiency.
                string createTablesSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE, Password TEXT NOT NULL, Role TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseID INTEGER PRIMARY KEY AUTOINCREMENT, CourseName TEXT NOT NULL UNIQUE
                );
                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectID INTEGER PRIMARY KEY AUTOINCREMENT, SubjectName TEXT NOT NULL, CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
                );
                CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL, CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
                );
                CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT, RoomName TEXT NOT NULL UNIQUE, RoomType TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT, SubjectID INTEGER, TimeSlot TEXT NOT NULL, RoomID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE,
                    FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID) ON DELETE CASCADE
                );
                CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT, ExamName TEXT NOT NULL, SubjectID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE
                );
                CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT, StudentID INTEGER NOT NULL, ExamID INTEGER NOT NULL, Score INTEGER,
                    FOREIGN KEY(StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
                    FOREIGN KEY(ExamID) REFERENCES Exams(ExamID) ON DELETE CASCADE,
                    UNIQUE(StudentID, ExamID)
                );";
                using (var command = new SQLiteCommand(createTablesSql, connection)) { await command.ExecuteNonQueryAsync(); }

                // Check if the database is new by seeing if the Users table is empty.
                string checkUserSql = "SELECT COUNT(*) FROM Users";
                using (var command = new SQLiteCommand(checkUserSql, connection))
                {
                    if (Convert.ToInt32(await command.ExecuteScalarAsync()) == 0)
                    {
                        // If empty, insert default data.
                        string insertDataSql = @"
                        INSERT INTO Users (Username, Password, Role) VALUES
                        ('admin', 'admin123', 'Admin'), ('staff1', 'staff123', 'Staff'), ('lecturer1', 'lecturer123', 'Lecturer');
                        INSERT INTO Rooms (RoomName, RoomType) VALUES
                        ('Lab 1', 'Lab'), ('Lab 2', 'Lab'), ('Hall A', 'Hall'), ('Hall B', 'Hall');";
                        using (var insertCommand = new SQLiteCommand(insertDataSql, connection)) { await insertCommand.ExecuteNonQueryAsync(); }
                    }
                }
            }
        }
        #endregion

        #region Login Methods
        /// <summary>
        /// Authenticates a user from the 'Users' table (Admin, Staff, Lecturer).
        /// </summary>
        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT UserID, Username, Role FROM Users WHERE Username = @username AND Password = @password";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new User { UserID = reader.GetInt32(0), Username = reader.GetString(1), Role = reader.GetString(2) };
                        }
                    }
                }
            }
            return null; // Return null if not found
        }

        /// <summary>
        /// Authenticates a user from the 'Students' table.
        /// </summary>
        public async Task<Student> GetStudentByUsernameAndPasswordAsync(string username, string password)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT StudentID, Name, Username, CourseID FROM Students WHERE Username = @username AND Password = @password";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Student { StudentID = reader.GetInt32(0), Name = reader.GetString(1), Username = reader.GetString(2), CourseID = reader.GetInt32(3) };
                        }
                    }
                }
            }
            return null; // Return null if not found
        }
        #endregion

        #region Course and Subject Methods
        public async Task AddCourseAsync(string courseName)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "INSERT OR IGNORE INTO Courses (CourseName) VALUES (@courseName)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseName", courseName);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = new List<Course>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT CourseID, CourseName FROM Courses ORDER BY CourseName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courses.Add(new Course
                            {
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString()
                            });
                        }
                    }
                }
            }
            return courses;
        }

        public async Task UpdateCourseAsync(int courseId, string courseName)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "UPDATE Courses SET CourseName = @courseName WHERE CourseID = @courseId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseName", courseName);
                    command.Parameters.AddWithValue("@courseId", courseId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Courses WHERE CourseID = @courseId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Subject>> GetSubjectsForCourseAsync(int courseId)
        {
            var subjects = new List<Subject>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT SubjectID, SubjectName, CourseID FROM Subjects WHERE CourseID = @courseId ORDER BY SubjectName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            });
                        }
                    }
                }
            }
            return subjects;
        }

        public async Task AddSubjectAsync(string subjectName, int courseId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@subjectName, @courseId)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@subjectName", subjectName);
                    command.Parameters.AddWithValue("@courseId", courseId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Student Methods
        public async Task AddStudentAsync(Student student)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Students (Name, Username, Password, CourseID) VALUES (@name, @username, @password, @courseId)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@username", student.Username);
                    command.Parameters.AddWithValue("@password", student.Password);
                    command.Parameters.AddWithValue("@courseId", student.CourseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = @"SELECT s.StudentID, s.Name, s.Username, s.CourseID, c.CourseName 
                               FROM Students s
                               LEFT JOIN Courses c ON s.CourseID = c.CourseID
                               ORDER BY s.Name";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                Name = reader["Name"].ToString(),
                                Username = reader["Username"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString()
                            });
                        }
                    }
                }
            }
            return students;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "UPDATE Students SET Name = @name, Username = @username, CourseID = @courseId WHERE StudentID = @studentId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@username", student.Username);
                    command.Parameters.AddWithValue("@courseId", student.CourseID);
                    command.Parameters.AddWithValue("@studentId", student.StudentID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Students WHERE StudentID = @studentId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Timetable and Dropdown Helper Methods
        public async Task AddTimetableEntryAsync(Timetable entry)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@subjectId, @timeSlot, @roomId)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@subjectId", entry.SubjectID);
                    command.Parameters.AddWithValue("@timeSlot", entry.TimeSlot);
                    command.Parameters.AddWithValue("@roomId", entry.RoomID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Timetable>> GetAllTimetableEntriesAsync()
        {
            var entries = new List<Timetable>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = @"SELECT t.TimetableID, t.SubjectID, t.TimeSlot, t.RoomID,
                                      s.SubjectName,
                                      r.RoomName
                               FROM Timetables t
                               LEFT JOIN Subjects s ON t.SubjectID = s.SubjectID
                               LEFT JOIN Rooms r ON t.RoomID = r.RoomID
                               ORDER BY t.TimeSlot";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            entries.Add(new Timetable
                            {
                                TimetableID = Convert.ToInt32(reader["TimetableID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                TimeSlot = reader["TimeSlot"].ToString(),
                                RoomID = Convert.ToInt32(reader["RoomID"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                RoomName = reader["RoomName"].ToString()
                            });
                        }
                    }
                }
            }
            return entries;
        }

        public async Task UpdateTimetableEntryAsync(Timetable entry)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "UPDATE Timetables SET SubjectID = @subjectId, TimeSlot = @timeSlot, RoomID = @roomId WHERE TimetableID = @timetableId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@subjectId", entry.SubjectID);
                    command.Parameters.AddWithValue("@timeSlot", entry.TimeSlot);
                    command.Parameters.AddWithValue("@roomId", entry.RoomID);
                    command.Parameters.AddWithValue("@timetableId", entry.TimetableID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteTimetableEntryAsync(int timetableId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Timetables WHERE TimetableID = @timetableId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@timetableId", timetableId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Subject>> GetAllSubjectsForTimetableAsync()
        {
            var subjects = new List<Subject>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT SubjectID, SubjectName FROM Subjects ORDER BY SubjectName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }
            return subjects;
        }

        public async Task<List<Room>> GetAllRoomsForTimetableAsync()
        {
            var rooms = new List<Room>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT RoomID, RoomName FROM Rooms ORDER BY RoomName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room
                            {
                                RoomID = Convert.ToInt32(reader["RoomID"]),
                                RoomName = reader["RoomName"].ToString()
                            });
                        }
                    }
                }
            }
            return rooms;
        }
        #endregion

        #region Exam and Marks Methods
        public async Task AddExamAsync(Exam exam)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Exams (ExamName, SubjectID) VALUES (@examName, @subjectId)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@examName", exam.ExamName);
                    command.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            var exams = new List<Exam>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = @"SELECT e.ExamID, e.ExamName, e.SubjectID, s.SubjectName
                               FROM Exams e
                               LEFT JOIN Subjects s ON e.SubjectID = s.SubjectID
                               ORDER BY s.SubjectName, e.ExamName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            exams.Add(new Exam
                            {
                                ExamID = Convert.ToInt32(reader["ExamID"]),
                                ExamName = reader["ExamName"].ToString(),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }
            return exams;
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "UPDATE Exams SET ExamName = @examName, SubjectID = @subjectId WHERE ExamID = @examId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@examName", exam.ExamName);
                    command.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                    command.Parameters.AddWithValue("@examId", exam.ExamID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteExamAsync(int examId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Exams WHERE ExamID = @examId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@examId", examId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Mark>> GetMarksForExamAsync(int examId)
        {
            var marks = new List<Mark>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = @"
                    SELECT 
                        s.StudentID, s.Name as StudentName, 
                        e.ExamID, e.ExamName, sub.SubjectName,
                        m.Score
                    FROM Students s
                    JOIN Subjects sub ON s.CourseID = sub.CourseID
                    JOIN Exams e ON sub.SubjectID = e.SubjectID
                    LEFT JOIN Marks m ON s.StudentID = m.StudentID AND e.ExamID = m.ExamID
                    WHERE e.ExamID = @examId
                    ORDER BY s.Name";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@examId", examId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            marks.Add(new Mark
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                StudentName = reader["StudentName"].ToString(),
                                ExamID = Convert.ToInt32(reader["ExamID"]),
                                ExamName = reader["ExamName"].ToString(),
                                SubjectName = reader["SubjectName"].ToString(),
                                Score = reader["Score"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Score"])
                            });
                        }
                    }
                }
            }
            return marks;
        }

        public async Task UpsertMarkAsync(Mark mark)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = @"
                    INSERT INTO Marks (StudentID, ExamID, Score) 
                    VALUES (@studentId, @examId, @score)
                    ON CONFLICT(StudentID, ExamID) DO UPDATE SET
                    Score = excluded.Score";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@studentId", mark.StudentID);
                    command.Parameters.AddWithValue("@examId", mark.ExamID);
                    command.Parameters.AddWithValue("@score", mark.Score);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion
    }
}