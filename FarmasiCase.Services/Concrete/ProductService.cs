using AutoMapper;
using FarmasiCase.Data.Abstract;
using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using FarmasiCase.Services.Abstract;
using FarmasiCase.Shared.Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FarmasiCase.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ProductDto Add(ProductDto dto)
        {
            var ProductEntity = _mapper.Map<Products>(dto);
            var responseEntity = _unitOfWork.ProductRepository.Add(ProductEntity);
            _unitOfWork.Save();
            return _mapper.Map<ProductDto>(responseEntity);
        }

        public void Delete(string id)
        {
            var ProductEntity = _unitOfWork.ProductRepository.Get(b => b.Id == id);
            if (ProductEntity != null)
            {
                ProductEntity.IsDeleted = true;
                ProductEntity.IsActive = false;
                _unitOfWork.ProductRepository.Delete(ProductEntity);
                _unitOfWork.Save();
            }
        }

        public ProductDto Get(Expression<Func<Products, bool>> predicate)
        {
            var entity = _unitOfWork.ProductRepository.Get(predicate);
            if (entity != null)
            {
                var dto = _mapper.Map<ProductDto>(entity);
                return dto;
            }
            return null;
        }

        public List<ProductDto> GetAll(Expression<Func<Products, bool>> predicate = null)
        {
            var data = _unitOfWork.ProductRepository.GetAllMongo();
            if (data != null)
            {
                var mappedList = _mapper.Map<List<ProductDto>>(data);
                return mappedList;
            }
            return null;
        }

        public PaginatedList<ProductDto> GetAllWithPaging(int pageIndex = 1, int pageSize = 10, Expression<Func<Products, bool>> predicate = null)
        {
            var paginatedData = _unitOfWork.ProductRepository.GetAllWithPaging(pageIndex, pageSize, predicate);
            if (paginatedData != null)
            {
                var mappedList = _mapper.Map<List<ProductDto>>(paginatedData);
                var response = new PaginatedList<ProductDto>(mappedList, paginatedData.Count, pageIndex, pageSize);
                return response;
            }
            return null;
        }


        public ProductDto Update(ProductDto dto)
        {
            var ProductEntity = _mapper.Map<Products>(dto);
            var responseEntity = _unitOfWork.ProductRepository.Update(ProductEntity);
            _unitOfWork.Save();
            return _mapper.Map<ProductDto>(responseEntity);
        }
    }
}
