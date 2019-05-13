using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Command
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }

        public IRepository Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        public IUnitFactory UnitFactory
        {
            get => this.unitFactory;
            set => this.unitFactory = value;
        }

        public abstract string Execute();
    }
}
