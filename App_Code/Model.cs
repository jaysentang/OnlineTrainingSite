﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class aspnetuser
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnetuser()
    {
        this.postcomments = new HashSet<postcomment>();
        this.posts = new HashSet<post>();
    }

    public string Id { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public string UserName { get; set; }
    public string ProjectId { get; set; }
    public Nullable<System.DateTime> LastLoginDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<postcomment> postcomments { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<post> posts { get; set; }
}

public partial class course
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public course()
    {
        this.posts = new HashSet<post>();
    }

    public string Id { get; set; }
    public string Header { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }
    public string SectionId { get; set; }
    public Nullable<int> CourseOrder { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<post> posts { get; set; }
}

public partial class post
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public post()
    {
        this.postcomments = new HashSet<postcomment>();
    }

    public int PostId { get; set; }
    public string Message { get; set; }
    public string PostedBy { get; set; }
    public System.DateTime PostedDate { get; set; }
    public string Course { get; set; }

    public virtual aspnetuser aspnetuser { get; set; }
    public virtual course course1 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<postcomment> postcomments { get; set; }
}

public partial class postcomment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Message { get; set; }
    public string CommentedBy { get; set; }
    public System.DateTime CommentedDate { get; set; }

    public virtual aspnetuser aspnetuser { get; set; }
    public virtual post post { get; set; }
}