﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudieJobsFinderMyDatabase.Models;

[Table("Virksomhed")]
public partial class Virksomhed
{
    [Key]
    [Column("VirksomhedsID")]
    public int VirksomhedsId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string VirksomhedsNavn { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Branche { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string HovedkvarterAdresse { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ByNavn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Land { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Telefonnummer { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Hjemmeside { get; set; }

    [InverseProperty("Virksomheds")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}