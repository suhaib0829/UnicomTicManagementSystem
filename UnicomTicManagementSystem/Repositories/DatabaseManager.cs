// In Repositories/DatabaseManager.cs
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;

namespace UnicomTicManagementSystem.Repositories
{

    public class DatabaseManager
    {
        // CREATE a new exam
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

        // READ all exams with their subject names for display
        public async Task<List<Exam>> GetAllExamsAsync()
        {
            var exams = new List<Exam>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // We use a JOIN to get the SubjectName for a user-friendly display
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
                                SubjectName = reader["SubjectName"].ToString() // From the JOIN
                            });
                        }
                    }
                }
            }
            return exams;
        }

        // UPDATE an existing exam
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

        // DELETE an exam
        public async Task DeleteExamAsync(int examId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // The 'ON DELETE CASCADE' in our Marks table will automatically delete all marks associated with this exam.
                string sql = "DELETE FROM Exams WHERE ExamID = @examId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@examId", examId);
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
        // CREATE a new timetable entry
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

        // READ all timetable entries with their Subject and Room names
        public async Task<List<Timetable>> GetAllTimetableEntriesAsync()
        {
            var entries = new List<Timetable>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // This is our most complex JOIN yet, combining THREE tables!
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
                                SubjectName = reader["SubjectName"].ToString(), // From Subjects table
                                RoomName = reader["RoomName"].ToString()        // From Rooms table
                            });
                        }
                    }
                }
            }
            return entries;
        }

        // UPDATE an existing timetable entry
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

        // DELETE a timetable entry
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

        // We also need methods to get all Subjects and Rooms to populate our dropdowns.
        // We can just create simple pass-through methods here for organization.
        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            // For this, we can write a new specific method or reuse one. Let's write one.
            var subjects = new List<Subject>();
            // ... logic to 'SELECT SubjectID, SubjectName FROM Subjects'
            // For now, let's assume we will write this logic later.
            // To keep moving, we will put this logic in the Controller for now.
            return null; // Placeholder
        }

        public Task<List<Room>> GetAllRoomsAsync()
        {
            // ... logic to 'SELECT RoomID, RoomName FROM Rooms'
            return null; // Placeholder
        }
        // CREATE a new student
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
                    command.Parameters.AddWithValue("@password", student.Password); // Plain text as per spec
                    command.Parameters.AddWithValue("@courseId", student.CourseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // READ all students with their course names
        // This is a more advanced query that gets data from two tables at once!
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // SQL JOIN fetches data from both Students and Courses tables
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
                                CourseName = reader["CourseName"].ToString() // This comes from the Courses table!
                            });
                        }
                    }
                }
            }
            return students;
        }

        // UPDATE an existing student
        public async Task UpdateStudentAsync(Student student)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // Note: For simplicity, we are not allowing password updates from this screen.
                // A real app would have a separate 'Change Password' feature.
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

        // DELETE a student
        public async Task DeleteStudentAsync(int studentId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // Deleting a student will also delete their marks due to 'ON DELETE CASCADE'
                string sql = "DELETE FROM Students WHERE StudentID = @studentId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        // CREATE a new course
        public async Task AddCourseAsync(string courseName)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // Using 'INSERT OR IGNORE' will prevent a crash if the course name already exists,
                // because we set the CourseName column to be UNIQUE.
                string sql = "INSERT OR IGNORE INTO Courses (CourseName) VALUES (@courseName)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseName", courseName);
                    await command.ExecuteNonQueryAsync(); // ExecuteNonQuery is used for INSERT, UPDATE, DELETE
                }
            }
        }

        // READ all courses
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = new List<Course>();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                string sql = "SELECT CourseID, CourseName FROM Courses ORDER BY CourseName";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync()) // ExecuteReader is used for SELECT
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

        // UPDATE an existing course
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

        // DELETE a course
        public async Task DeleteCourseAsync(int courseId)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                // Because we used 'ON DELETE CASCADE' in our table schema,
                // deleting a course will also automatically delete all subjects, students,
                // and timetables associated with it. This is very powerful.
                string sql = "DELETE FROM Courses WHERE CourseID = @courseId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
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
                            return new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Role = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null; // Not found
        }

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
                            return new Student
                            {
                                StudentID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Username = reader.GetString(2),
                                CourseID = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }
            return null; // Not found
        }
        private static readonly Lazy<DatabaseManager> _instance = new Lazy<DatabaseManager>(() => new DatabaseManager());
        public static DatabaseManager Instance => _instance.Value;

        private readonly string _connectionString;
        private const string DbFileName = "unicomtic.db";

        private DatabaseManager()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            _connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabaseAsync().Wait();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        private async Task InitializeDatabaseAsync()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();

                string createTablesSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL CHECK(Role IN ('Admin', 'Staff', 'Lecturer'))
                );

                CREATE TABLE IF NOT EXISTS Courses (
                    CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL UNIQUE
                );

                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomName TEXT NOT NULL UNIQUE,
                    RoomType TEXT NOT NULL CHECK(RoomType IN ('Lab', 'Hall'))
                );

                CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectID INTEGER,
                    TimeSlot TEXT NOT NULL,
                    RoomID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE,
                    FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    SubjectID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    ExamID INTEGER,
                    Score INTEGER,
                    FOREIGN KEY(StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
                    FOREIGN KEY(ExamID) REFERENCES Exams(ExamID) ON DELETE CASCADE
                );
                ";

                using (var command = new SQLiteCommand(createTablesSql, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }

                string checkUserSql = "SELECT COUNT(*) FROM Users";
                using (var command = new SQLiteCommand(checkUserSql, connection))
                {
                    if (Convert.ToInt32(await command.ExecuteScalarAsync()) == 0)
                    {
                        string insertDataSql = @"
                        INSERT INTO Users (Username, Password, Role) VALUES
                        ('admin', 'admin123', 'Admin'),
                        ('staff1', 'staff123', 'Staff'),
                        ('lecturer1', 'lecturer123', 'Lecturer');

                        INSERT INTO Rooms (RoomName, RoomType) VALUES
                        ('Lab 1', 'Lab'), ('Lab 2', 'Lab'), ('Hall A', 'Hall'), ('Hall B', 'Hall');
                        ";
                        using (var insertCommand = new SQLiteCommand(insertDataSql, connection))
                        {
                            await insertCommand.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
        }
    }
}