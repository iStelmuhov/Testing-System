﻿using System;

namespace TestingSystem.Exceptions.ServiceValidation
{
    public class ServiceUnresolvedEntityException : ServiceValidationException
    {
        public ServiceUnresolvedEntityException(Type entityType, Guid entityId)
            : base(
                string.Format(
                    "Unresolved entity #{1} of type {0}",
                    entityType.ToString(), entityId
                )
            )
        { }
    }
}