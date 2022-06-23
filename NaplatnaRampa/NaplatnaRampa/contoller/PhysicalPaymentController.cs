using Autofac;
using NaplatnaRampa.model;
using NaplatnaRampa.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatnaRampa.contoller
{
    class PhysicalPaymentController
    {
        public IPhysicalPaymentRepository physicalPaymentRepository;
        public PhysicalPaymentController()
        {
            this.physicalPaymentRepository = Globals.container.Resolve<IPhysicalPaymentRepository>();
        }

        public void Save(PhysicalPayment payment)
        {
            physicalPaymentRepository.Insert(payment);
        }
    }
}
