using Autofac;
using MongoDB.Bson;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    public class PaymentController
    {

        public IPaymentRepository paymentRepository;

        public PaymentController()
        {
            this.paymentRepository = Globals.container.Resolve<IPaymentRepository>();
        }

        public Payment GetById(ObjectId id)
        {
            return paymentRepository.GetById(id);
        }


    }
}
