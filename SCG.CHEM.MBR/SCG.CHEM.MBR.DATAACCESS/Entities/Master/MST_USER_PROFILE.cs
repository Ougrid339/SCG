using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MST_USER_PROFILE")]
    public class MST_USER_PROFILE
    {
        [Key]
        [Column("USER_ID")]
        [StringLength(50)]
        public string UserId { get; private set; }

        [Column("FIRST_NAME")]
        [StringLength(50)]
        public string FirstName { get; private set; }

        [Column("LAST_NAME")]
        [StringLength(50)]
        public string LastName { get; private set; }

        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; private set; }

        [Column("PURCHASING_GROUP_ID")]
        [StringLength(3)]
        public string? PurchasingGroupId { get; set; }

        [Column("DELETE_FLAG")]
        public bool DeleteFlag { get; private set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; private set; }

        [Column("UPDATED_DATE")]
        public DateTime? UpdatedDate { get; private set; }

        [Column("UPDATED_BY")]
        [StringLength(50)]
        public string? UpdateBy { get; private set; }

        public static MST_USER_PROFILE Create(string userId, string firstName, string lastName, string email)
        {
            var db = new MST_USER_PROFILE()
            {
                UserId = userId?.ToLower(),
                FirstName = firstName,
                LastName = lastName,
                Email = email?.ToLower(),
                CreatedDate = DateTime.Now,
                DeleteFlag = false,
            };
            return db;
        }

        public void Update(UserDetailModel model, string user)
        {
            this.UpdatedDate = DateTime.Now;
            this.UpdateBy = user;
        }

        public void Delete(string user)
        {
            this.DeleteFlag = true;
            this.UpdateBy = user;
            this.UpdatedDate = DateTime.Now;
        }

        public void SetActive(bool? status, string user)
        {
            this.DeleteFlag = !status.GetValueOrDefault();
            this.UpdateBy = user;
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UpdateBy = AppConstant.APP_USER.SYSTEM;
            this.UpdatedDate = DateTime.Now;
        }
    }
}