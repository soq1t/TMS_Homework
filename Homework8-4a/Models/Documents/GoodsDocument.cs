using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_4a.Models.Documents
{
    internal class GoodsDocument : Document
    {
        public override string Type => "Контракт на поставку товаров";

        public string GoodsType { get; private set; }

        public int? GoodsAmount { get; private set; }

        public GoodsDocument(string goodsType, int? goodsAmount, DateOnly creationDate)
            : base(creationDate)
        {
            GoodsType = goodsType;
            GoodsAmount = goodsAmount;
        }

        public GoodsDocument(string goodsType, int? goodsAmount)
            : this(goodsType, goodsAmount, DateOnly.FromDateTime(DateTime.Now)) { }

        public GoodsDocument()
            : this(null, null) { }

        public override void PrintInfo()
        {
            base.PrintInfo();
            if (GoodsType != null)
                ConsoleUtility.WriteLineColored(
                    new Colored("Тип товаров: ", ConsoleColor.Cyan),
                    new Colored($"[{GoodsType}]", ConsoleColor.Green)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Тип товаров: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );

            if (GoodsAmount.HasValue)
                ConsoleUtility.WriteLineColored(
                    new Colored("Количество товаров: ", ConsoleColor.Cyan),
                    new Colored($"[{GoodsAmount}]", ConsoleColor.Green)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Количество товаров: ", ConsoleColor.Cyan),
                    new Colored($"[отсутствует]", ConsoleColor.Red)
                );
        }
    }
}
