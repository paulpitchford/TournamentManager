﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IPoints
    {
        public int NextPosition(List<int> numbers);
    }
}
