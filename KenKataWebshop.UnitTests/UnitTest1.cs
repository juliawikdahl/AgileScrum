using KenkataWebshop.Data;
using KenkataWebshop.WebClient.Controllers;
using KenkataWebshop.WebClient.Models;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace KenKataWebshop.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ProductController_MapToViewModel()
        {
            // Arrange
            var name = "Name1";
            var dto = new ProductDto
            {
                Name = name,
            };

            // Act
            var viewModel = dto.MapToViewModel();

            // Assert
            Assert.Equal(name, viewModel.Name);
        }

        [Fact]
        public void ProductController_MapToViewModelArray()
        {
            // Arrange
            var dtos = new List<ProductDto>();

            for (int i = 0; i < 5; ++i)
            {
                dtos.Add(new ProductDto() { Name = $"product_{i}" });
            }

            //Act
            List<ProductViewModel> viewModels = dtos.Select(dto => dto.MapToViewModel()).ToList();

            // Assert
            Assert.Equal(dtos.Count, viewModels.Count);
            for(int i = 0; i < viewModels.Count; ++i)
            {
                Assert.Equal(dtos[i].Name, viewModels[i].Name);
            }
        }

    }
}