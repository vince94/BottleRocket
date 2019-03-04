﻿using BottleRocket;
using NUnit.Framework;

namespace HackinTests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void ItemToPointerTableEntry()
        {
            var expectedEntry = new byte[]
            {
                //the Aluminum Bat. info from http://pkhack.fobby.net/misc/txt/eb0_1810.txt
                0x72,
                0x80,
                0x01,
                0x1E,
                0x02,
                0x00,
                0xE8,
                0x03
            };

            var test = new Item
            {
                NameTextOffset = "0082", //pointer is 4A80. swap it. 804A - 7FF0 = 5A <-- actual offset
                NintenUsable = true,
                AnaUsable = false,
                LloydUsable = false,
                TeddyUsable = false,
                Unknown1 = false,
                Unknown2 = false,
                Edible = false,
                Permanent = false,
                EquippableStrength = 0b011110,
                Type = "Weapon",
                EffectOutsideOfBattle = 0x02,
                EffectInBattle = 0x00,
                Price = 1000
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }

        [Test]
        public void PointerTableEntryToItem()
        {
            var tableEntry = new byte[]
            {
                //the Aluminum Bat
                0x72,
                0x80,
                0x01,
                0x1E,
                0x02,
                0x00,
                0xE8,
                0x03
            };

            var expectedItem = new Item
            {
                NameTextOffset = "0082",
                NintenUsable = true,
                AnaUsable = false,
                LloydUsable = false,
                TeddyUsable = false,
                Unknown1 = false,
                Unknown2 = false,
                Edible = false,
                Permanent = false,
                EquippableStrength = 0b011110,
                Type = "Weapon",
                EffectOutsideOfBattle = 0x02,
                EffectInBattle = 0x00,
                Price = 1000
            };

            var test = Item.ParseHex(tableEntry);

            //It doesn't seem to work if I compare the objects directly, so I'm going to try this
            Assert.AreEqual(expectedItem.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedItem.NintenUsable, test.NintenUsable);
            Assert.AreEqual(expectedItem.AnaUsable, test.AnaUsable);
            Assert.AreEqual(expectedItem.LloydUsable, test.LloydUsable);
            Assert.AreEqual(expectedItem.TeddyUsable, test.TeddyUsable);
            Assert.AreEqual(expectedItem.Unknown1, test.Unknown1);
            Assert.AreEqual(expectedItem.Unknown2, test.Unknown2);
            Assert.AreEqual(expectedItem.Edible, test.Edible);
            Assert.AreEqual(expectedItem.Permanent, test.Permanent);
            Assert.AreEqual(expectedItem.EquippableStrength, test.EquippableStrength);
            Assert.AreEqual(expectedItem.Type, test.Type);
            Assert.AreEqual(expectedItem.EffectOutsideOfBattle, test.EffectOutsideOfBattle);
            Assert.AreEqual(expectedItem.EffectInBattle, test.EffectInBattle);
            Assert.AreEqual(expectedItem.Price, test.Price);
        }


        [Test]
        public void ItemToPointerTableEntry_NewTotallyRadicalExtendedOffset()
        {
            var expectedEntry = new byte[]
            {
                //the Bullhorn
                0x6D,
                0x83,
                0x3F,
                0x00,
                0x00,
                0x3C,
                0x00,
                0x00
            };

            var test = new Item
            {
                NameTextOffset = "037D",
                NintenUsable = true,
                AnaUsable = true,
                LloydUsable = true,
                TeddyUsable = true,
                Unknown1 = true,
                Unknown2 = true,
                Edible = false,
                Permanent = false,
                EquippableStrength = 0,
                Type = "Weapon",
                EffectOutsideOfBattle = 0x00,
                EffectInBattle = 0x3C,
                Price = 0
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }

        [Test]
        public void PointerTableEntryToItem_NewTotallyRadicalExtendedOffset()
        {
            var tableEntry = new byte[]
            {
                //the Bullhorn
                0x6D,
                0x83,
                0x3F,
                0x00,
                0x00,
                0x3C,
                0x00,
                0x00
            };

            var expectedItem = new Item
            {
                NameTextOffset = "037D",
                NintenUsable = true,
                AnaUsable = true,
                LloydUsable = true,
                TeddyUsable = true,
                Unknown1 = true,
                Unknown2 = true,
                Edible = false,
                Permanent = false,
                EquippableStrength = 0,
                Type = "Weapon",
                EffectOutsideOfBattle = 0x00,
                EffectInBattle = 0x3C,
                Price = 0
            };

            var test = Item.ParseHex(tableEntry);

            //It doesn't seem to work if I compare the objects directly, so I'm going to try this
            Assert.AreEqual(expectedItem.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedItem.NintenUsable, test.NintenUsable);
            Assert.AreEqual(expectedItem.AnaUsable, test.AnaUsable);
            Assert.AreEqual(expectedItem.LloydUsable, test.LloydUsable);
            Assert.AreEqual(expectedItem.TeddyUsable, test.TeddyUsable);
            Assert.AreEqual(expectedItem.Unknown1, test.Unknown1);
            Assert.AreEqual(expectedItem.Unknown2, test.Unknown2);
            Assert.AreEqual(expectedItem.Edible, test.Edible);
            Assert.AreEqual(expectedItem.Permanent, test.Permanent);
            Assert.AreEqual(expectedItem.EquippableStrength, test.EquippableStrength);
            Assert.AreEqual(expectedItem.Type, test.Type);
            Assert.AreEqual(expectedItem.EffectOutsideOfBattle, test.EffectOutsideOfBattle);
            Assert.AreEqual(expectedItem.EffectInBattle, test.EffectInBattle);
            Assert.AreEqual(expectedItem.Price, test.Price);
        }
    }
}
