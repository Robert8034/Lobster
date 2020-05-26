using System;
using System.Reflection;
using Lobster.Core.Data;
using Lobster.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;

namespace Lobster.Server.Services.Test
{
    public static class MockExtensions
    {
        public static void SetupRepositoryMock<T>(this Mock<Repository<T>> repositoryMock, Action<IRepository<T>> options) where T : BaseEntity
        {
            var context = new LobsterTestContext();
            context.Database.EnsureDeleted();

            var constructorArguments = repositoryMock.GetType().GetField("constructorArguments",
                BindingFlags.NonPublic | BindingFlags.Instance);
            constructorArguments?.SetValue(repositoryMock, new object[] { context });

            repositoryMock.Protected().SetupGet<DbSet<T>>("Entities").Returns(context.Set<T>());
            repositoryMock.Setup(repository => repository.Table).Returns(context.Set<T>());
            repositoryMock.Setup(repository => repository.TableNoTracking).Returns(context.Set<T>().AsNoTracking);

            options.Invoke(repositoryMock.Object);

            context.SaveChanges();
        }
    }
}
