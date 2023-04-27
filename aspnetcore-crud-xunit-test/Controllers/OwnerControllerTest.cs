using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using aspnetcore_crud.Controllers;
using aspnetcore_crud.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_crud_xunit_test.Controllers
{
    public class OwnerControllerTest
    {
        private List<Owner> GetOwnerData()
        {
            List<Owner> ownersData = new List<Owner>
            {
                new Owner
                {
                    Id = 24, Name = "Nguyễn Văn Hảo", DateOfBirth = new DateTime(1978, 3, 21), Address = "123 Phan Châu Trinh"
                },
                 new Owner
                {
                    Id = 25, Name = "Nguyễn Văn Hào", DateOfBirth = new DateTime(1979, 3, 21), Address = "123 Phan Châu Trinh"
                },
                 new Owner
                {
                    Id = 26, Name = "Nguyễn Văn Háo", DateOfBirth = new DateTime(1980, 3, 21), Address = "123 Phan Châu Trinh"
                },
            };
            return ownersData;
        }

        private readonly Mock<IOwnerRepository> ownerRepository;
        private readonly IUnitofWork unitofWork;
        public OwnerControllerTest()
        {
            ownerRepository = new Mock<IOwnerRepository>();
        }

        [Fact]
        public void Test_GetEntities()
        {
            //arrange
            var ownerList = GetOwnerData();
            ownerRepository.Setup(x => x.GetEntities())
                .ReturnsAsync(ownerList);
            var ownerController = new OwnerController(unitofWork);

            //act
            var ownerResult = ownerController.GetOwners();

            //assert
            Assert.NotNull(ownerResult);
            /*Assert.Equal(GetOwnerData().Count(), ownerResult);*/
            Assert.Equal(GetOwnerData().ToString(), ownerResult.ToString());
            Assert.True(GetOwnerData().Equals(ownerResult));
        }

        [Fact]
        public void OwnerController_TestCreate()
        {
            var ownerController = new OwnerController(unitofWork);
            Assert.NotNull(ownerController);
        }
    }
}
