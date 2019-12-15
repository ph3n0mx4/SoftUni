﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        //•	SongId – integer, Primary Key
        //•	Song – the performer’s song(required)
        //•	PerformerId – integer, Primary Key
        //•	Performer – the song’s performer(required)
        public int SongId { get; set; }
        [Required]
        public Song Song { get; set; }

        public int PerformerId { get; set; }
        [Required]
        public Performer Performer { get; set; }
    }
}
