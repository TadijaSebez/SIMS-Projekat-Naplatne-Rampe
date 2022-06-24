using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using MongoDB.Bson;

namespace NaplatnaRampa.contoller
{
    public class AddressController
    {
        public IAddressRepository addressRepository;

        public AddressController()
        {
            this.addressRepository = Globals.container.Resolve<IAddressRepository>();
        }

        public Address GetById(ObjectId id)
        {
            return addressRepository.GetById(id);
        }

        public void Save(Address address)
        {
            addressRepository.Insert(address);
        }

    }
}
