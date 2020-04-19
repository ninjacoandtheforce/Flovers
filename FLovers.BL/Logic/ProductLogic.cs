﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLovers.BL.BaseClasses;
using FLovers.DAL.Repository.BaseClasses;
using FLovers.DAL.Repository.Dtos;
using FLovers.DAL.Repository.Entities;
using FLovers.Log.Services.Logging;
using FLovers.Shared.BaseClasses;
using FLovers.Shared.Enums;
using FLovers.Shared.Extensions;
using FLovers.Shared.RequestObjects;

namespace FLovers.BL.Logic
{
    public class ProductLogic : LogicBase<ProductDto, Product>
    {
        private Repository<Branch> BranchRepository { get; set; }
        public virtual ResponseBase AssignAProductToAStore(int branchId, int productId, RequestBase requestBase)
        {
            var response = new ResponseBase();
            try
            {
                BranchRepository = new Repository<Branch>();
                var product = Repository.Get(new GetByIdRequest<Product>(productId, requestBase));
                if (product != null)
                {
                    var branch = BranchRepository.Get(new GetByIdRequest<Branch>(branchId, requestBase));
                    if (branch != null)
                    {
                        branch.Products.Add(product);
                        response.IsSuccess = true;
                        return response;
                    }
                }

                response.ErrorMessage = "Please refer to logs for error.";
                response.IsSuccess = false;
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }
    }
}