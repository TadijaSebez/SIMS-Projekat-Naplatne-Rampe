using System;
using System.Collections.Generic;
using System.Text;
using NaplatnaRampa.repository;
using NaplatnaRampa.model;
using Autofac;
using MongoDB.Bson;
namespace NaplatnaRampa.contoller
{
    public class TollRoadController
    {
        public ITollRoadRepository tollRoadRepository;

        public TollRoadController()
        {
            this.tollRoadRepository = Globals.container.Resolve<ITollRoadRepository>();
        }

        public TollRoad GetByStationAndNumber(TollStation station, int number)
        {
            return tollRoadRepository.GetByStationAndNumber(station._id, number);
        }
      
        public TollRoad GetById(ObjectId id)
        {
            return tollRoadRepository.GetById(id);
        }

        public void Insert(TollRoad tollRoad) {
            tollRoadRepository.Insert(tollRoad);
        
        }


        public TollRoad GetByStationAndNumber(ObjectId tollstaitonId, int number) {
            foreach (TollRoad t in tollRoadRepository.GetAll())
            {
                if (t.tollStationId.Equals(tollstaitonId) && t.number == number)
                {
                    return t;
                }

            }

            return null;
        }

        public void Update(TollRoad tollroad) {
            tollRoadRepository.Update(tollroad);
        
        }
        public void Delete(TollRoad t) {
            tollRoadRepository.Delete(t._id);
        }

        public List<Int32> getNums(TollStation station)
        {
            List<Int32> nums = new List<Int32>();
            foreach (TollRoad t in tollRoadRepository.GetAllInStation(station._id)){
                nums.Add(t.number);
                
            }
            return nums;


        }
    }
}
