﻿using Microsoft.Extensions.Logging;
using Providence.Models;
using Providence.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Providence.Service.Implement
{
    public class AccountCRUD : IServiceCRUD<Account>
    {
        private readonly DatabaseContext _databaseContext;
        private IConfiguration configuration;

        public AccountCRUD(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            this.configuration = configuration;
        }

        public bool Create(Account account)
        {
            try
            {
                _databaseContext.Accounts.Add(account);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var account = _databaseContext.Accounts.FirstOrDefault(p => p.AccountId == id);
                if (account != null)
                {
                    _databaseContext.Accounts.Remove(account);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Accounts.Where(acc => acc.AccountId == id).Select(acc => new
        {
            accountId = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            password = acc.Password,
            phoneNumber = acc.Phone,
            gender = acc.Gender,
            address = acc.Address.RoadName,
            avatar = configuration["BaseUrl"] + "/images/" + acc.Avatar,
            roleid = acc.RoleId,
            rolename = acc.Role.RoleName,
            status = acc.Status,
            securitycode = acc.SecurityCode,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).FirstOrDefault()!;

        public dynamic Read() => _databaseContext.Accounts.Select(acc => new
        {
            accountId = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            password = acc.Password,
            phoneNumber = acc.Phone,
            gender = acc.Gender,
            address = acc.Address.RoadName,
            avatar = configuration["BaseUrl"] + "/images/" + acc.Avatar,
            roleid = acc.RoleId,
            rolename = acc.Role.RoleName,
            status = acc.Status,
            securitycode = acc.SecurityCode,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).ToList();

        public bool Update(Account account)
        {
            try
            {
                // Tìm kiếm tài khoản theo AccountId
                var existingAccount = _databaseContext.Accounts.FirstOrDefault(a => a.AccountId == account.AccountId);
                if (existingAccount == null)
                {
                    return false; // Không tìm thấy tài khoản
                }

                // Không cho phép thay đổi email, status và created at
                account.Email = existingAccount.Email;
                account.Password = existingAccount.Password;
                account.Status = existingAccount.Status;
                account.CreatedAt = existingAccount.CreatedAt;

                // Cập nhật các thuộc tính khác
                _databaseContext.Entry(existingAccount).CurrentValues.SetValues(account);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }

            //try
            //{
            //    _databaseContext.Accounts.Update(account);
            //    return _databaseContext.SaveChanges() > 0;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
    }
}
