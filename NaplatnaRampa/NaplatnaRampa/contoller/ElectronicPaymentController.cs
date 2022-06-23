using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;

namespace NaplatnaRampa.contoller
{
    public class ElectronicPaymentController
    {
        public IElectronicPaymentRepository paymentRepository;

        public ElectronicPaymentController()
        {
            this.paymentRepository = Globals.container.Resolve<IElectronicPaymentRepository>();
        }

        public ElectronicPayment GetById(ObjectId id)
        {
            return paymentRepository.GetById(id);
        }
    }
}
