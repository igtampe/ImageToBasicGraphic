﻿using System.Drawing;
using Igtampe.BasicGraphics;

namespace Igtampe.ImageToBasicGraphic {
    public class HiColorPixelProcessor: PixelProcessor {

        /// <summary>Pairs of colors from HC format to Color</summary>
        public static readonly ColorPair[] Pairs = {
            new ColorPair("000",ColorTranslator.FromHtml("#0C0C0C")),
            new ColorPair("010",ColorTranslator.FromHtml("#09163F")),
            new ColorPair("020",ColorTranslator.FromHtml("#0D310C")),
            new ColorPair("030",ColorTranslator.FromHtml("#172E40")),
            new ColorPair("040",ColorTranslator.FromHtml("#3A0C10")),
            new ColorPair("050",ColorTranslator.FromHtml("#2B0E2F")),
            new ColorPair("060",ColorTranslator.FromHtml("#393009")),
            new ColorPair("070",ColorTranslator.FromHtml("#3C3C3C")),
            new ColorPair("080",ColorTranslator.FromHtml("#262626")),
            new ColorPair("090",ColorTranslator.FromHtml("#172748")),
            new ColorPair("0A0",ColorTranslator.FromHtml("#0E3A0C")),
            new ColorPair("0B0",ColorTranslator.FromHtml("#213E3E")),
            new ColorPair("0C0",ColorTranslator.FromHtml("#421B1E")),
            new ColorPair("0D0",ColorTranslator.FromHtml("#360930")),
            new ColorPair("0E0",ColorTranslator.FromHtml("#474532")),
            new ColorPair("0F0",ColorTranslator.FromHtml("#454545")),
            new ColorPair("100",ColorTranslator.FromHtml("#032CA6")),
            new ColorPair("110",ColorTranslator.FromHtml("#0037DA")),
            new ColorPair("120",ColorTranslator.FromHtml("#0451A7")),
            new ColorPair("130",ColorTranslator.FromHtml("#0E4EDA")),
            new ColorPair("140",ColorTranslator.FromHtml("#312DAB")),
            new ColorPair("150",ColorTranslator.FromHtml("#222FC9")),
            new ColorPair("160",ColorTranslator.FromHtml("#3050A3")),
            new ColorPair("170",ColorTranslator.FromHtml("#335CD6")),
            new ColorPair("180",ColorTranslator.FromHtml("#1D46C1")),
            new ColorPair("190",ColorTranslator.FromHtml("#0E47E3")),
            new ColorPair("1A0",ColorTranslator.FromHtml("#055AA6")),
            new ColorPair("1B0",ColorTranslator.FromHtml("#185ED9")),
            new ColorPair("1C0",ColorTranslator.FromHtml("#393BB9")),
            new ColorPair("1D0",ColorTranslator.FromHtml("#2D29CB")),
            new ColorPair("1E0",ColorTranslator.FromHtml("#3E65CC")),
            new ColorPair("1F0",ColorTranslator.FromHtml("#3C65E0")),
            new ColorPair("200",ColorTranslator.FromHtml("#117B0D")),
            new ColorPair("210",ColorTranslator.FromHtml("#0E8641")),
            new ColorPair("220",ColorTranslator.FromHtml("#13A10E")),
            new ColorPair("230",ColorTranslator.FromHtml("#1C9E41")),
            new ColorPair("240",ColorTranslator.FromHtml("#3F7C12")),
            new ColorPair("250",ColorTranslator.FromHtml("#307E30")),
            new ColorPair("260",ColorTranslator.FromHtml("#3E9F0A")),
            new ColorPair("270",ColorTranslator.FromHtml("#41AB3D")),
            new ColorPair("280",ColorTranslator.FromHtml("#2B9628")),
            new ColorPair("290",ColorTranslator.FromHtml("#1D964A")),
            new ColorPair("2A0",ColorTranslator.FromHtml("#13AA0D")),
            new ColorPair("2B0",ColorTranslator.FromHtml("#26AE40")),
            new ColorPair("2C0",ColorTranslator.FromHtml("#488A20")),
            new ColorPair("2D0",ColorTranslator.FromHtml("#3B7832")),
            new ColorPair("2E0",ColorTranslator.FromHtml("#4CB533")),
            new ColorPair("2F0",ColorTranslator.FromHtml("#4AB547")),
            new ColorPair("300",ColorTranslator.FromHtml("#2E73A8")),
            new ColorPair("310",ColorTranslator.FromHtml("#2B7EDC")),
            new ColorPair("320",ColorTranslator.FromHtml("#3098A9")),
            new ColorPair("330",ColorTranslator.FromHtml("#3A96DD")),
            new ColorPair("340",ColorTranslator.FromHtml("#5C74AD")),
            new ColorPair("350",ColorTranslator.FromHtml("#4D76CB")),
            new ColorPair("360",ColorTranslator.FromHtml("#5B97A5")),
            new ColorPair("370",ColorTranslator.FromHtml("#5EA3D8")),
            new ColorPair("380",ColorTranslator.FromHtml("#498EC3")),
            new ColorPair("390",ColorTranslator.FromHtml("#3A8EE5")),
            new ColorPair("3A0",ColorTranslator.FromHtml("#31A2A8")),
            new ColorPair("3B0",ColorTranslator.FromHtml("#43A6DB")),
            new ColorPair("3C0",ColorTranslator.FromHtml("#6582BB")),
            new ColorPair("3D0",ColorTranslator.FromHtml("#5870CD")),
            new ColorPair("3E0",ColorTranslator.FromHtml("#69ACCF")),
            new ColorPair("3F0",ColorTranslator.FromHtml("#68ADE2")),
            new ColorPair("400",ColorTranslator.FromHtml("#960E1A")),
            new ColorPair("410",ColorTranslator.FromHtml("#93194D")),
            new ColorPair("420",ColorTranslator.FromHtml("#98331A")),
            new ColorPair("430",ColorTranslator.FromHtml("#A2304E")),
            new ColorPair("440",ColorTranslator.FromHtml("#C50F1F")),
            new ColorPair("450",ColorTranslator.FromHtml("#B5113D")),
            new ColorPair("460",ColorTranslator.FromHtml("#C43217")),
            new ColorPair("470",ColorTranslator.FromHtml("#C63E4A")),
            new ColorPair("480",ColorTranslator.FromHtml("#B12834")),
            new ColorPair("490",ColorTranslator.FromHtml("#A22957")),
            new ColorPair("4A0",ColorTranslator.FromHtml("#993C1A")),
            new ColorPair("4B0",ColorTranslator.FromHtml("#AC404C")),
            new ColorPair("4C0",ColorTranslator.FromHtml("#CD1D2C")),
            new ColorPair("4D0",ColorTranslator.FromHtml("#C00B3E")),
            new ColorPair("4E0",ColorTranslator.FromHtml("#D24740")),
            new ColorPair("4F0",ColorTranslator.FromHtml("#D04753")),
            new ColorPair("500",ColorTranslator.FromHtml("#691475")),
            new ColorPair("510",ColorTranslator.FromHtml("#661FA8")),
            new ColorPair("520",ColorTranslator.FromHtml("#6A3975")),
            new ColorPair("530",ColorTranslator.FromHtml("#7436A9")),
            new ColorPair("540",ColorTranslator.FromHtml("#971579")),
            new ColorPair("550",ColorTranslator.FromHtml("#881798")),
            new ColorPair("560",ColorTranslator.FromHtml("#963872")),
            new ColorPair("570",ColorTranslator.FromHtml("#9944A5")),
            new ColorPair("580",ColorTranslator.FromHtml("#832E8F")),
            new ColorPair("590",ColorTranslator.FromHtml("#742FB1")),
            new ColorPair("5A0",ColorTranslator.FromHtml("#6B4275")),
            new ColorPair("5B0",ColorTranslator.FromHtml("#7E46A7")),
            new ColorPair("5C0",ColorTranslator.FromHtml("#9F2387")),
            new ColorPair("5D0",ColorTranslator.FromHtml("#931199")),
            new ColorPair("5E0",ColorTranslator.FromHtml("#A44D9B")),
            new ColorPair("5F0",ColorTranslator.FromHtml("#A24DAE")),
            new ColorPair("600",ColorTranslator.FromHtml("#937803")),
            new ColorPair("610",ColorTranslator.FromHtml("#908236")),
            new ColorPair("620",ColorTranslator.FromHtml("#959D03")),
            new ColorPair("630",ColorTranslator.FromHtml("#9F9A37")),
            new ColorPair("640",ColorTranslator.FromHtml("#C27807")),
            new ColorPair("650",ColorTranslator.FromHtml("#B27A26")),
            new ColorPair("660",ColorTranslator.FromHtml("#C19C00")),
            new ColorPair("670",ColorTranslator.FromHtml("#C3A833")),
            new ColorPair("680",ColorTranslator.FromHtml("#AE921D")),
            new ColorPair("690",ColorTranslator.FromHtml("#9F933F")),
            new ColorPair("6A0",ColorTranslator.FromHtml("#96A603")),
            new ColorPair("6B0",ColorTranslator.FromHtml("#A9AA35")),
            new ColorPair("6C0",ColorTranslator.FromHtml("#CA8715")),
            new ColorPair("6D0",ColorTranslator.FromHtml("#BD7527")),
            new ColorPair("6E0",ColorTranslator.FromHtml("#CFB129")),
            new ColorPair("6F0",ColorTranslator.FromHtml("#CDB13C")),
            new ColorPair("700",ColorTranslator.FromHtml("#9C9C9C")),
            new ColorPair("710",ColorTranslator.FromHtml("#99A6CF")),
            new ColorPair("720",ColorTranslator.FromHtml("#9DC19C")),
            new ColorPair("730",ColorTranslator.FromHtml("#A7BED0")),
            new ColorPair("740",ColorTranslator.FromHtml("#CA9CA0")),
            new ColorPair("750",ColorTranslator.FromHtml("#BB9EBF")),
            new ColorPair("760",ColorTranslator.FromHtml("#C9C099")),
            new ColorPair("770",ColorTranslator.FromHtml("#CCCCCC")),
            new ColorPair("780",ColorTranslator.FromHtml("#B6B6B6")),
            new ColorPair("790",ColorTranslator.FromHtml("#A7B7D8")),
            new ColorPair("7A0",ColorTranslator.FromHtml("#9ECA9C")),
            new ColorPair("7B0",ColorTranslator.FromHtml("#B1CECE")),
            new ColorPair("7C0",ColorTranslator.FromHtml("#D2ABAE")),
            new ColorPair("7D0",ColorTranslator.FromHtml("#C699C0")),
            new ColorPair("7E0",ColorTranslator.FromHtml("#D7D5C2")),
            new ColorPair("7F0",ColorTranslator.FromHtml("#D5D5D5")),
            new ColorPair("800",ColorTranslator.FromHtml("#5B5B5B")),
            new ColorPair("810",ColorTranslator.FromHtml("#58668F")),
            new ColorPair("820",ColorTranslator.FromHtml("#5D805C")),
            new ColorPair("830",ColorTranslator.FromHtml("#677E8F")),
            new ColorPair("840",ColorTranslator.FromHtml("#895C60")),
            new ColorPair("850",ColorTranslator.FromHtml("#7A5E7E")),
            new ColorPair("860",ColorTranslator.FromHtml("#887F58")),
            new ColorPair("870",ColorTranslator.FromHtml("#8B8B8B")),
            new ColorPair("880",ColorTranslator.FromHtml("#767676")),
            new ColorPair("890",ColorTranslator.FromHtml("#677698")),
            new ColorPair("8A0",ColorTranslator.FromHtml("#5E8A5B")),
            new ColorPair("8B0",ColorTranslator.FromHtml("#708E8E")),
            new ColorPair("8C0",ColorTranslator.FromHtml("#926A6E")),
            new ColorPair("8D0",ColorTranslator.FromHtml("#855880")),
            new ColorPair("8E0",ColorTranslator.FromHtml("#969481")),
            new ColorPair("8F0",ColorTranslator.FromHtml("#959595")),
            new ColorPair("900",ColorTranslator.FromHtml("#2F5DC2")),
            new ColorPair("910",ColorTranslator.FromHtml("#2C67F5")),
            new ColorPair("920",ColorTranslator.FromHtml("#3182C2")),
            new ColorPair("930",ColorTranslator.FromHtml("#3A7FF6")),
            new ColorPair("940",ColorTranslator.FromHtml("#5D5DC7")),
            new ColorPair("950",ColorTranslator.FromHtml("#4E5FE5")),
            new ColorPair("960",ColorTranslator.FromHtml("#5C81BF")),
            new ColorPair("970",ColorTranslator.FromHtml("#5F8DF2")),
            new ColorPair("980",ColorTranslator.FromHtml("#4977DC")),
            new ColorPair("990",ColorTranslator.FromHtml("#3B78FF")),
            new ColorPair("9A0",ColorTranslator.FromHtml("#318BC2")),
            new ColorPair("9B0",ColorTranslator.FromHtml("#448FF4")),
            new ColorPair("9C0",ColorTranslator.FromHtml("#666CD4")),
            new ColorPair("9D0",ColorTranslator.FromHtml("#595AE6")),
            new ColorPair("9E0",ColorTranslator.FromHtml("#6A96E8")),
            new ColorPair("9F0",ColorTranslator.FromHtml("#6896FB")),
            new ColorPair("A00",ColorTranslator.FromHtml("#13970C")),
            new ColorPair("A10",ColorTranslator.FromHtml("#10A23F")),
            new ColorPair("A20",ColorTranslator.FromHtml("#15BC0C")),
            new ColorPair("A30",ColorTranslator.FromHtml("#1FBA40")),
            new ColorPair("A40",ColorTranslator.FromHtml("#419810")),
            new ColorPair("A50",ColorTranslator.FromHtml("#329A2F")),
            new ColorPair("A60",ColorTranslator.FromHtml("#40BB09")),
            new ColorPair("A70",ColorTranslator.FromHtml("#43C73C")),
            new ColorPair("A80",ColorTranslator.FromHtml("#2EB226")),
            new ColorPair("A90",ColorTranslator.FromHtml("#1FB248")),
            new ColorPair("AA0",ColorTranslator.FromHtml("#16C60C")),
            new ColorPair("AB0",ColorTranslator.FromHtml("#28CA3E")),
            new ColorPair("AC0",ColorTranslator.FromHtml("#4AA61E")),
            new ColorPair("AD0",ColorTranslator.FromHtml("#3D9430")),
            new ColorPair("AE0",ColorTranslator.FromHtml("#4ED032")),
            new ColorPair("AF0",ColorTranslator.FromHtml("#4DD145")),
            new ColorPair("B00",ColorTranslator.FromHtml("#4BA3A3")),
            new ColorPair("B10",ColorTranslator.FromHtml("#48AED7")),
            new ColorPair("B20",ColorTranslator.FromHtml("#4DC8A4")),
            new ColorPair("B30",ColorTranslator.FromHtml("#57C6D7")),
            new ColorPair("B40",ColorTranslator.FromHtml("#7AA4A8")),
            new ColorPair("B50",ColorTranslator.FromHtml("#6AA6C6")),
            new ColorPair("B60",ColorTranslator.FromHtml("#79C7A0")),
            new ColorPair("B70",ColorTranslator.FromHtml("#7BD3D3")),
            new ColorPair("B80",ColorTranslator.FromHtml("#66BEBE")),
            new ColorPair("B90",ColorTranslator.FromHtml("#57BEE0")),
            new ColorPair("BA0",ColorTranslator.FromHtml("#4ED2A3")),
            new ColorPair("BB0",ColorTranslator.FromHtml("#61D6D6")),
            new ColorPair("BC0",ColorTranslator.FromHtml("#82B2B6")),
            new ColorPair("BD0",ColorTranslator.FromHtml("#75A0C8")),
            new ColorPair("BE0",ColorTranslator.FromHtml("#87DCC9")),
            new ColorPair("BF0",ColorTranslator.FromHtml("#85DDDD")),
            new ColorPair("C00",ColorTranslator.FromHtml("#B03943")),
            new ColorPair("C10",ColorTranslator.FromHtml("#AD4377")),
            new ColorPair("C20",ColorTranslator.FromHtml("#B25E44")),
            new ColorPair("C30",ColorTranslator.FromHtml("#BB5B77")),
            new ColorPair("C40",ColorTranslator.FromHtml("#DE3948")),
            new ColorPair("C50",ColorTranslator.FromHtml("#CF3B66")),
            new ColorPair("C60",ColorTranslator.FromHtml("#DD5D40")),
            new ColorPair("C70",ColorTranslator.FromHtml("#E06973")),
            new ColorPair("C80",ColorTranslator.FromHtml("#CA535E")),
            new ColorPair("C90",ColorTranslator.FromHtml("#BC5480")),
            new ColorPair("CA0",ColorTranslator.FromHtml("#B26743")),
            new ColorPair("CB0",ColorTranslator.FromHtml("#C56B76")),
            new ColorPair("CC0",ColorTranslator.FromHtml("#E74856")),
            new ColorPair("CD0",ColorTranslator.FromHtml("#DA3668")),
            new ColorPair("CE0",ColorTranslator.FromHtml("#EB7269")),
            new ColorPair("CF0",ColorTranslator.FromHtml("#E9727D")),
            new ColorPair("D00",ColorTranslator.FromHtml("#8A0379")),
            new ColorPair("D10",ColorTranslator.FromHtml("#870DAD")),
            new ColorPair("D20",ColorTranslator.FromHtml("#8B287A")),
            new ColorPair("D30",ColorTranslator.FromHtml("#9525AD")),
            new ColorPair("D40",ColorTranslator.FromHtml("#B8037E")),
            new ColorPair("D50",ColorTranslator.FromHtml("#A9059C")),
            new ColorPair("D60",ColorTranslator.FromHtml("#B72776")),
            new ColorPair("D70",ColorTranslator.FromHtml("#BA33A9")),
            new ColorPair("D80",ColorTranslator.FromHtml("#A41D94")),
            new ColorPair("D90",ColorTranslator.FromHtml("#951EB6")),
            new ColorPair("DA0",ColorTranslator.FromHtml("#8C3179")),
            new ColorPair("DB0",ColorTranslator.FromHtml("#9F35AC")),
            new ColorPair("DC0",ColorTranslator.FromHtml("#C0128C")),
            new ColorPair("DD0",ColorTranslator.FromHtml("#B4009E")),
            new ColorPair("DE0",ColorTranslator.FromHtml("#C53C9F")),
            new ColorPair("DF0",ColorTranslator.FromHtml("#C33CB3")),
            new ColorPair("E00",ColorTranslator.FromHtml("#BDB77E")),
            new ColorPair("E10",ColorTranslator.FromHtml("#BAC2B2")),
            new ColorPair("E20",ColorTranslator.FromHtml("#BFDD7F")),
            new ColorPair("E30",ColorTranslator.FromHtml("#C9DAB3")),
            new ColorPair("E40",ColorTranslator.FromHtml("#ECB883")),
            new ColorPair("E50",ColorTranslator.FromHtml("#DCBAA1")),
            new ColorPair("E60",ColorTranslator.FromHtml("#EBDB7B")),
            new ColorPair("E70",ColorTranslator.FromHtml("#EDE7AE")),
            new ColorPair("E80",ColorTranslator.FromHtml("#D8D299")),
            new ColorPair("E90",ColorTranslator.FromHtml("#C9D2BB")),
            new ColorPair("EA0",ColorTranslator.FromHtml("#C0E67E")),
            new ColorPair("EB0",ColorTranslator.FromHtml("#D3EAB1")),
            new ColorPair("EC0",ColorTranslator.FromHtml("#F4C691")),
            new ColorPair("ED0",ColorTranslator.FromHtml("#E7B4A3")),
            new ColorPair("EE0",ColorTranslator.FromHtml("#F9F1A5")),
            new ColorPair("EF0",ColorTranslator.FromHtml("#F7F1B8")),
            new ColorPair("F00",ColorTranslator.FromHtml("#B8B8B8")),
            new ColorPair("F10",ColorTranslator.FromHtml("#B5C3EC")),
            new ColorPair("F20",ColorTranslator.FromHtml("#BADDB9")),
            new ColorPair("F30",ColorTranslator.FromHtml("#C4DBEC")),
            new ColorPair("F40",ColorTranslator.FromHtml("#E6B9BD")),
            new ColorPair("F50",ColorTranslator.FromHtml("#D7BBDB")),
            new ColorPair("F60",ColorTranslator.FromHtml("#E5DCB5")),
            new ColorPair("F70",ColorTranslator.FromHtml("#E8E8E8")),
            new ColorPair("F80",ColorTranslator.FromHtml("#D3D3D3")),
            new ColorPair("F90",ColorTranslator.FromHtml("#C4D3F5")),
            new ColorPair("FA0",ColorTranslator.FromHtml("#BBE7B8")),
            new ColorPair("FB0",ColorTranslator.FromHtml("#CDEBEB")),
            new ColorPair("FC0",ColorTranslator.FromHtml("#EFC7CB")),
            new ColorPair("FD0",ColorTranslator.FromHtml("#E2B5DD")),
            new ColorPair("FE0",ColorTranslator.FromHtml("#F3F1DE")),
            new ColorPair("FF0",ColorTranslator.FromHtml("#F2F2F2")),
            new ColorPair("011",ColorTranslator.FromHtml("#062173")),
            new ColorPair("021",ColorTranslator.FromHtml("#0F560D")),
            new ColorPair("031",ColorTranslator.FromHtml("#235174")),
            new ColorPair("041",ColorTranslator.FromHtml("#680D15")),
            new ColorPair("051",ColorTranslator.FromHtml("#4A1152")),
            new ColorPair("061",ColorTranslator.FromHtml("#665406")),
            new ColorPair("071",ColorTranslator.FromHtml("#6C6C6C")),
            new ColorPair("081",ColorTranslator.FromHtml("#414141")),
            new ColorPair("091",ColorTranslator.FromHtml("#234285")),
            new ColorPair("0A1",ColorTranslator.FromHtml("#11690C")),
            new ColorPair("0B1",ColorTranslator.FromHtml("#367171")),
            new ColorPair("0C1",ColorTranslator.FromHtml("#792A31")),
            new ColorPair("0D1",ColorTranslator.FromHtml("#600655")),
            new ColorPair("0E1",ColorTranslator.FromHtml("#827E58")),
            new ColorPair("0F1",ColorTranslator.FromHtml("#7F7F7F")),
            new ColorPair("121",ColorTranslator.FromHtml("#096C74")),
            new ColorPair("131",ColorTranslator.FromHtml("#1D66DB")),
            new ColorPair("141",ColorTranslator.FromHtml("#62237C")),
            new ColorPair("151",ColorTranslator.FromHtml("#4427B9")),
            new ColorPair("161",ColorTranslator.FromHtml("#60696D")),
            new ColorPair("171",ColorTranslator.FromHtml("#6681D3")),
            new ColorPair("181",ColorTranslator.FromHtml("#3B56A8")),
            new ColorPair("191",ColorTranslator.FromHtml("#1D57EC")),
            new ColorPair("1A1",ColorTranslator.FromHtml("#0B7E73")),
            new ColorPair("1B1",ColorTranslator.FromHtml("#3086D8")),
            new ColorPair("1C1",ColorTranslator.FromHtml("#733F98")),
            new ColorPair("1D1",ColorTranslator.FromHtml("#5A1BBC")),
            new ColorPair("1E1",ColorTranslator.FromHtml("#7C94BF")),
            new ColorPair("1F1",ColorTranslator.FromHtml("#7994E6")),
            new ColorPair("231",ColorTranslator.FromHtml("#269B75")),
            new ColorPair("241",ColorTranslator.FromHtml("#6C5816")),
            new ColorPair("251",ColorTranslator.FromHtml("#4D5C53")),
            new ColorPair("261",ColorTranslator.FromHtml("#6A9E07")),
            new ColorPair("271",ColorTranslator.FromHtml("#6FB66D")),
            new ColorPair("281",ColorTranslator.FromHtml("#448B42")),
            new ColorPair("291",ColorTranslator.FromHtml("#278C86")),
            new ColorPair("2A1",ColorTranslator.FromHtml("#14B30D")),
            new ColorPair("2B1",ColorTranslator.FromHtml("#3ABB72")),
            new ColorPair("2C1",ColorTranslator.FromHtml("#7D7432")),
            new ColorPair("2D1",ColorTranslator.FromHtml("#635056")),
            new ColorPair("2E1",ColorTranslator.FromHtml("#86C959")),
            new ColorPair("2F1",ColorTranslator.FromHtml("#82C980")),
            new ColorPair("341",ColorTranslator.FromHtml("#7F527E")),
            new ColorPair("351",ColorTranslator.FromHtml("#6156BA")),
            new ColorPair("361",ColorTranslator.FromHtml("#7D996E")),
            new ColorPair("371",ColorTranslator.FromHtml("#83B1D4")),
            new ColorPair("381",ColorTranslator.FromHtml("#5886A9")),
            new ColorPair("391",ColorTranslator.FromHtml("#3A87EE")),
            new ColorPair("3A1",ColorTranslator.FromHtml("#28AE74")),
            new ColorPair("3B1",ColorTranslator.FromHtml("#4DB6D9")),
            new ColorPair("3C1",ColorTranslator.FromHtml("#906F99")),
            new ColorPair("3D1",ColorTranslator.FromHtml("#774BBD")),
            new ColorPair("3E1",ColorTranslator.FromHtml("#99C3C1")),
            new ColorPair("3F1",ColorTranslator.FromHtml("#96C4E7")),
            new ColorPair("451",ColorTranslator.FromHtml("#A6135B")),
            new ColorPair("461",ColorTranslator.FromHtml("#C3550F")),
            new ColorPair("471",ColorTranslator.FromHtml("#C86D75")),
            new ColorPair("481",ColorTranslator.FromHtml("#9D424A")),
            new ColorPair("491",ColorTranslator.FromHtml("#80438F")),
            new ColorPair("4A1",ColorTranslator.FromHtml("#6D6A15")),
            new ColorPair("4B1",ColorTranslator.FromHtml("#93727A")),
            new ColorPair("4C1",ColorTranslator.FromHtml("#D62B3A")),
            new ColorPair("4D1",ColorTranslator.FromHtml("#BC075E")),
            new ColorPair("4E1",ColorTranslator.FromHtml("#DF8062")),
            new ColorPair("4F1",ColorTranslator.FromHtml("#DB8088")),
            new ColorPair("561",ColorTranslator.FromHtml("#A4594C")),
            new ColorPair("571",ColorTranslator.FromHtml("#AA71B2")),
            new ColorPair("581",ColorTranslator.FromHtml("#7F4687")),
            new ColorPair("591",ColorTranslator.FromHtml("#6147CB")),
            new ColorPair("5A1",ColorTranslator.FromHtml("#4F6E52")),
            new ColorPair("5B1",ColorTranslator.FromHtml("#7476B7")),
            new ColorPair("5C1",ColorTranslator.FromHtml("#B72F77")),
            new ColorPair("5D1",ColorTranslator.FromHtml("#9E0B9B")),
            new ColorPair("5E1",ColorTranslator.FromHtml("#C0849E")),
            new ColorPair("5F1",ColorTranslator.FromHtml("#BD84C5")),
            new ColorPair("671",ColorTranslator.FromHtml("#C6B466")),
            new ColorPair("681",ColorTranslator.FromHtml("#9B893B")),
            new ColorPair("691",ColorTranslator.FromHtml("#7E8A7F")),
            new ColorPair("6A1",ColorTranslator.FromHtml("#6BB106")),
            new ColorPair("6B1",ColorTranslator.FromHtml("#91B96B")),
            new ColorPair("6C1",ColorTranslator.FromHtml("#D4722B")),
            new ColorPair("6D1",ColorTranslator.FromHtml("#BA4E4F")),
            new ColorPair("6E1",ColorTranslator.FromHtml("#DDC652")),
            new ColorPair("6F1",ColorTranslator.FromHtml("#D9C779")),
            new ColorPair("781",ColorTranslator.FromHtml("#A1A1A1")),
            new ColorPair("791",ColorTranslator.FromHtml("#83A2E5")),
            new ColorPair("7A1",ColorTranslator.FromHtml("#71C96C")),
            new ColorPair("7B1",ColorTranslator.FromHtml("#96D1D1")),
            new ColorPair("7C1",ColorTranslator.FromHtml("#D98A91")),
            new ColorPair("7D1",ColorTranslator.FromHtml("#C066B5")),
            new ColorPair("7E1",ColorTranslator.FromHtml("#E2DEB8")),
            new ColorPair("7F1",ColorTranslator.FromHtml("#DFDFDF")),
            new ColorPair("891",ColorTranslator.FromHtml("#5877BA")),
            new ColorPair("8A1",ColorTranslator.FromHtml("#469E41")),
            new ColorPair("8B1",ColorTranslator.FromHtml("#6BA6A6")),
            new ColorPair("8C1",ColorTranslator.FromHtml("#AE5F66")),
            new ColorPair("8D1",ColorTranslator.FromHtml("#953B8A")),
            new ColorPair("8E1",ColorTranslator.FromHtml("#B7B38D")),
            new ColorPair("8F1",ColorTranslator.FromHtml("#B4B4B4")),
            new ColorPair("9A1",ColorTranslator.FromHtml("#289F85")),
            new ColorPair("9B1",ColorTranslator.FromHtml("#4EA7EA")),
            new ColorPair("9C1",ColorTranslator.FromHtml("#9160AA")),
            new ColorPair("9D1",ColorTranslator.FromHtml("#773CCE")),
            new ColorPair("9E1",ColorTranslator.FromHtml("#9AB4D2")),
            new ColorPair("9F1",ColorTranslator.FromHtml("#96B5F8")),
            new ColorPair("AB1",ColorTranslator.FromHtml("#3BCE71")),
            new ColorPair("AC1",ColorTranslator.FromHtml("#7E8731")),
            new ColorPair("AD1",ColorTranslator.FromHtml("#656355")),
            new ColorPair("AE1",ColorTranslator.FromHtml("#87DB58")),
            new ColorPair("AF1",ColorTranslator.FromHtml("#84DC7F")),
            new ColorPair("BC1",ColorTranslator.FromHtml("#A48F96")),
            new ColorPair("BD1",ColorTranslator.FromHtml("#8A6BBA")),
            new ColorPair("BE1",ColorTranslator.FromHtml("#ADE3BD")),
            new ColorPair("BF1",ColorTranslator.FromHtml("#A9E4E4")),
            new ColorPair("CD1",ColorTranslator.FromHtml("#CD247A")),
            new ColorPair("CE1",ColorTranslator.FromHtml("#F09C7D")),
            new ColorPair("CF1",ColorTranslator.FromHtml("#EC9DA4")),
            new ColorPair("DE1",ColorTranslator.FromHtml("#D678A1")),
            new ColorPair("DF1",ColorTranslator.FromHtml("#D379C8")),
            new ColorPair("EF1",ColorTranslator.FromHtml("#F5F1CB"))
        };

        /// <summary>Creates a HiColor pixel processor</summary>
        public HiColorPixelProcessor() { Name = "HiColorGraphic Pixel Processor"; }

        public override string Process(Color Pixel) {
            //Mira esto es lo que va a pasar
            ColorPair ClosestPair = Pairs[0];
            double Difference = ColourDistance(Pixel, Pairs[0].color);

            foreach (ColorPair pair in Pairs) {
                double NewDifference = ColourDistance(Pixel, pair.color);
                if (NewDifference < Difference) { ClosestPair = pair; Difference = NewDifference; }
            }

            DrawPixel(ClosestPair.Data);
            DrawPixel(ClosestPair.Data);

            return ClosestPair.Data + "-" + ClosestPair.Data + "-";
        }

        public override void DrawPixel(string ColorString) { HiColorGraphic.HiColorDraw(ColorString); }
    }
}
