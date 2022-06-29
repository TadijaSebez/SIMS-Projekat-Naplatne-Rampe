using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NaplatnaRampa.contoller;
using NaplatnaRampa.repository;

namespace NaplatnaRampa
{
    internal class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<TollRoadRepository>().As<ITollRoadRepository>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
            builder.RegisterType<SlipRepository>().As<ISlipRepository>();
            builder.RegisterType<SectionRepository>().As<ISectionRepository>();
            builder.RegisterType<PlaceRepository>().As<IPlaceRepository>();
            builder.RegisterType<PhysicalPaymentRepository>().As<IPhysicalPaymentRepository>();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            builder.RegisterType<ElectronicPaymentRepository>().As<IElectronicPaymentRepository>();
            builder.RegisterType<DriverRepository>().As<IDriverRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>();
            builder.RegisterType<TollStationRepository>().As<ITollStationRepository>();
            builder.RegisterType<PricelistRepository>().As<IPricelistRepository>();
            builder.RegisterType<MalfunctionRepository>().As<IMalfunctionRepository>();
            builder.RegisterType<PricelistItemRepository>().As<IPricelistItemRepository>();
            builder.RegisterType<MalfunctionRepository>().As<IMalfunctionRepository>();
            
            builder.RegisterType<UserController>().SingleInstance();
            builder.RegisterType<AddressController>().AsSelf();
            builder.RegisterType<PlaceController>().AsSelf();
            builder.RegisterType<PricelistController>().AsSelf();
            builder.RegisterType<PricelistItemController>().AsSelf();
            builder.RegisterType<SectionController>().AsSelf();
            builder.RegisterType<TollStationController>().AsSelf();
            builder.RegisterType<TollRoadController>().AsSelf();
            builder.RegisterType<SlipController>().AsSelf();
            builder.RegisterType<PhysicalPaymentController>().AsSelf();
            builder.RegisterType<DriverController>().AsSelf();
            builder.RegisterType<MalfunctionController>().SingleInstance();
            builder.RegisterType<PaymentController>().AsSelf();
            builder.RegisterType<TollRoadController>().SingleInstance();
        }
    }
}
