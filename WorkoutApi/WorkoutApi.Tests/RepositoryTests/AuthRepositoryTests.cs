using Moq;
using Microsoft.Data.SqlClient;
using WorkoutApi.Repositories;
using WorkoutApi.Models;
using System.Data;

namespace WorkoutApi.Tests.RepositoryTests
{
    public class AuthRepositoryTests
    {
        private readonly Mock<IDbConnection> _mockConnection;
        private readonly Mock<IDbCommand> _mockCommand;
        private readonly Mock<IDataReader> _mockReader;
        private readonly AuthRepository _authRepository;

        public AuthRepositoryTests()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockReader = new Mock<IDataReader>();
            _mockConnection.Setup(c => c.CreateCommand()).Returns(_mockCommand.Object);
            _authRepository = new AuthRepository(_mockConnection.Object);
        }

        #region AuthenticateUser



        #endregion

        #region RegisterUser



        #endregion

    }
}
