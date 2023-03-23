﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask100HPGames.Enemy
{
    interface IDamageable
    {
        public void TakeDamage(float damage);
        public void Die();
    }
}
