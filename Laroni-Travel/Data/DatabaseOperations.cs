using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace dal
{
    public static class DatabaseOperations
    {
        public static List<Deelnemer> OphalenKDeelnemers()
        {
            using (Laroni_TravelContext ctx = new Laroni_TravelContext())
            {
                //var query = ctx.Deelnemers.Include("Deelnemers");
                var query = ctx.Deelnemers
                              .Include(x => x.DeelnemerId)
                              .OrderBy(x => x.DeelnemerId);
                return query.ToList();
            }
        }

        //    public static List<Klant> OphalenKlantenOrdersOrderlijnen()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Klanten
        //                          .Include("Orders.Orderlijnen")
        //                          .OrderBy(x => x.Bedrijf);
        //            //var query = ctx.Klanten
        //            //            .Include(x=> x.Orders.Select(sub=> sub.Orderlijnen))
        //            //            .OrderBy(x => x.Bedrijf);
        //            return query.ToList();
        //        }
        //    }

        //    public static List<Klant> OphalenKlantenOrdersOrderlijnenProduct()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Klanten
        //                          .Include("Orders.Orderlijnen.Product")
        //                          .OrderBy(x => x.Bedrijf);
        //            //var query = ctx.Klanten
        //            //             .Include(x => x.Orders.Select(sub => sub.Orderlijnen.Select(sub2 => sub2.Product)))
        //            //             .OrderBy(x => x.Bedrijf);
        //            return query.ToList();
        //        }
        //    }

        //    public static List<Klant> OphalenKlantenOrdersOrderlijnenProductWerknemers()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Klanten
        //                          .Include("Orders.Orderlijnen.Product")
        //                          .Include("Orders.Werknemer")
        //                          .OrderBy(x => x.Bedrijf);
        //            //var query = ctx.Klanten
        //            //              .Include(x => x.Orders.Select(sub => sub.Orderlijnen.Select(sub2 => sub2.Product)))
        //            //              .Include(x => x.Orders.Select(sub => sub.Werknemer))
        //            //              .OrderBy(x => x.Bedrijf);
        //            return query.ToList();
        //        }
        //    }

        //    public static List<Order> OphalenOrders()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Orders
        //                        .Include("Klant")
        //                        .Include("Werknemer");
        //            //var query = ctx.Orders
        //            //            .Include(x => x.Klant)
        //            //            .Include(x => x.Werknemer);
        //            return query.ToList();

        //            //return ctx.Orders
        //            //    .Include(x => x.Orderlijnen)
        //            //    .GroupBy(x => new { x.OrderID, x.Klantnummer })
        //            //    .Select(x => new
        //            //    {
        //            //        ID = x.Key.OrderID,
        //            //        Titel = x.Key.Klantnummer,
        //            //        AantalAlbums = x.Sum(y => y.ID)
        //            //        AantalAlbums = x.Average(y => y.Orderlijnen.Select(z => z.Productnummer)).
        //            //        GemiddeldeWaardering = x.Albums.Average()
        //            //    })
        //            //    .OrderBy(x => x.Titel)
        //            //    .ToList();
        //        }
        //    }

        //    public static Order OphalenOrderViaOrderID(int orderID)
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Orders
        //                        .Include(x => x.Orderlijnen)
        //                        .Include(x => x.Klant)
        //                        .Include(x => x.Werknemer)
        //                        .Where(x => x.OrderID == orderID);
        //            return query.SingleOrDefault();
        //        }
        //    }

        //    public static List<Orderlijn> OphalenOrderlijnenViaOrderID(int orderID)
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Orderlijnen
        //                        .Include(x => x.Product)
        //                        .Where(x => x.OrderID == orderID);
        //            return query.ToList();
        //        }
        //    }

        //    public static List<Product> OphalenProducten()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Producten;
        //            return query.ToList();
        //        }
        //    }

        //    public static List<Klant> OphalenKlanten()
        //    {
        //        using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //        {
        //            var query = ctx.Klanten;
        //            return query.ToList();
        //        }
        //    }

        //    public static int ToevoegenOrderlijn(Orderlijn orderlijn)
        //    {
        //        try
        //        {
        //            using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //            {
        //                ctx.Orderlijnen.Add(orderlijn);
        //                return ctx.SaveChanges();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            FileOperations.FoutLoggen(ex);
        //            return 0;
        //        }
        //    }

        //    public static int AanpassenOrderlijn(Orderlijn orderlijn)
        //    {
        //        try
        //        {
        //            using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //            {
        //                ctx.Entry(orderlijn).State = EntityState.Modified;
        //                return ctx.SaveChanges();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            FileOperations.FoutLoggen(ex);
        //            return 0;
        //        }
        //    }

        //    public static int VerwijderenOrderlijn(Orderlijn orderlijn)
        //    {
        //        try
        //        {
        //            using (VerkoopBeheerContext ctx = new VerkoopBeheerContext())
        //            {
        //                ctx.Entry(orderlijn).State = EntityState.Deleted;
        //                return ctx.SaveChanges();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            FileOperations.FoutLoggen(ex);
        //            return 0;
        //        }
        //    }
    }
}