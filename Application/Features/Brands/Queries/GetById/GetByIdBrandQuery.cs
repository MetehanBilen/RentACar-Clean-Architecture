﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdBrandQuery:IRequest<GetByIdBrandResponse>
    {

        public Guid Id { get; set; }

        public class GetByIdBrandQueryHandler:IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse> 
            // GetByIdBrandQuery için bir handlersuın ve dönüş tipin GetByIdBrandResponse
        {

            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
               Brand? brand =  await _brandRepository.GetAsync(predicate: b => b.Id == request.Id ,cancellationToken:cancellationToken); //request.Id= yukardaki Id
                                //GetAsyn withDeleted=false
               GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(brand);

                return response;
            
            }
        }


    }



}
