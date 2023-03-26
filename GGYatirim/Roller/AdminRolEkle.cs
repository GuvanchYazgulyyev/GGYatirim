using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GGYatirim.Roller
{
    public class AdminRolEkle : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

       
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        // İşlem Burada Yapıldı
        public override string[] GetRolesForUser(string username)
        {
            GYatirimEntities dr = new GYatirimEntities();
        
            var k = dr.DbAdmin.FirstOrDefault(f => f.EPosta == username);
            return new string[] { k.DbYetki.YetkiAd };
            //throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {

            // Kullanıcı Yetkili Kısmı
            //GYatirimEntities dr = new GYatirimEntities();

            //var k = dr.DbKullanici.FirstOrDefault(f => f.EPosta == roleName);
            //return new string[] { k.DbYetki.YetkiAd };
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}