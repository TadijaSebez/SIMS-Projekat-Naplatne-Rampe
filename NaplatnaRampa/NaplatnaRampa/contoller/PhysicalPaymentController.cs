using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
namespace NaplatnaRampa.contoller
{
    public class PhysicalPaymentController
    {
        public IPhysicalPaymentRepository paymentRepository;

        public PhysicalPaymentController()
        {
            this.paymentRepository = Globals.container.Resolve<IPhysicalPaymentRepository>();
        }

        public PhysicalPayment GetById(ObjectId id)
        {
            return paymentRepository.GetById(id);
        }
      
        public void Save(PhysicalPayment payment)
        {
            paymentRepository.Insert(payment);
        }
    }
}
