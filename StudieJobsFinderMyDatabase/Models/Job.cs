﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudieJobsFinderMyDatabase.Models;

[Table("Job")]
public partial class Job
{
    [Key]
    [Column("JobID")]
    public int JobId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Titel { get; set; }

    [Column(TypeName = "text")]
    public string Beskrivelse { get; set; }

    [Column(TypeName = "date")]
    public DateTime? OffentliggørelsesDato { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Deadline { get; set; }

    [Column("VirksomhedsID")]
    public int? VirksomhedsId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Lokation { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Løn { get; set; }

    [Column(TypeName = "text")]
    public string Kompetencer { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required]
    public string Kategori { get; set; }

    [ForeignKey("VirksomhedsId")]
    [InverseProperty("Jobs")]
    public virtual Virksomhed Virksomheds { get; set; }
}