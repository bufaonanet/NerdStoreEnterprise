﻿using NSE.Core.Data;
using System.Threading.Tasks;

namespace NSE.Pedido.Domain.Vouchers
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);       
    }
}
