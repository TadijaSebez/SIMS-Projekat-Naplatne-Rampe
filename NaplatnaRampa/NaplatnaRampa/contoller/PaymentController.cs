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

        public List<Payment> GetPaymentsSpecified(int number)
        {
            //DateTime added = DateTime.Now.AddDays(-number);
            //Console.WriteLine(added);
            List<Payment> payments = new List<Payment>();
            foreach(Payment payment in paymentRepository.GetAll())
            {
                payments.Add(payment);
                /*if (payment.dateTime >= added)
                {
                    Console.WriteLine(payment.dateTime);
                    payments.Add(payment);
                }*/
            }
            return payments;
        }
    }
}
