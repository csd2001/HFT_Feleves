using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Logic.Classes;
using LLQ0P5_HFT_2022231.Models;
using LLQ0P5_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LLQ0P5_HFT_2022231.Test
{
    [TestFixture]
    public class Test
    {
        PlayLogic playLogic;
        RoleLogic roleLogic;
        DirectorLogic directorLogic;
        ActorLogic actorLogic;
        Mock<IRepository<Play>> mockPlay;
        Mock<IRepository<Role>> mockRole;
        Mock<IRepository<Director>> mockDirector;
        Mock<IRepository<Actor>> mockActor;


        [SetUp]
        public void Init()
        {
            mockPlay = new Mock<IRepository<Play>>();
            mockPlay.Setup(m => m.ReadAll()).Returns(new List<Play>()
            {
                 new Play()
            {
                PlayID = 3,
                Title = "Háry János",
                ReleaseDate = DateTime.Parse("1926.10.16"),
                Rating = 9.4,
                DirectorId=3,
                Director= new Director(){
                    DirectorId = 1,
                    Name = "Goldmark Károly" },
                Income=1000,
                 Actors = new List<Actor>()
                {
                    new Actor(){
                   ActorId = 2,
                   ActorName = "Ádám Máté",

                    },
                       new Actor(){
                   ActorId = 1,
                   ActorName = "Ádám Ádám",
                    },
                 },
                Roles = new List<Role>()
                {
                    new Role()
                    {
                    RoleID = 1,
                    ActorId = 1,
                    PlayId = 1,
                    Rolename = "Tankred Dorst",
                    }
                }

            },
                new Play(){
                PlayID = 1,
                Title = "Merlin",
                ReleaseDate = DateTime.Parse("1889.11.19"),
                Rating = 9.4,
                DirectorId=1,
                Income = 2000,
                Director= new Director(){
                    DirectorId = 1,
                    Name = "Goldmark Károly" },
                Actors = new List<Actor>()
                {
                    new Actor(){
                   ActorId = 1,
                   ActorName = "Ádám Kornél",

                    }
                },
                Roles = new List<Role>()
                {
                    new Role()
                    {
                    RoleID = 1,
                    ActorId = 1,
                    PlayId = 1,
                    Rolename = "Tankred Dorst",
                    }
                }


                },
                new Play()
            {
                PlayID = 2,
                Title = "Bánk bán",
                ReleaseDate = DateTime.Parse("1883.02.19"),
                Rating = 7.4,
                DirectorId=2,
                Income = 1000,
                Director= new Director(){
                    DirectorId = 1,
                    Name = "Goldmark Károly" },
                 Actors = new List<Actor>()
                {
                    new Actor(){
                   ActorId = 1,
                   ActorName = "Ádám Kornél",

                    }
                },
                Roles = new List<Role>()
                {
                    new Role()
                    {
                    RoleID = 1,
                    ActorId = 1,
                    PlayId = 1,
                    Rolename = "Tankred Dorst",
                    }
                }

            },
                new Play()
            {
                PlayID = 3,
                Title = "Háry Péter",
                ReleaseDate = DateTime.Parse("1926.10.16"),
                Rating = 9.4,
                DirectorId=3,
                Income = 1000,
                Director= new Director(){
                    DirectorId = 1,
                    Name = "Goldmark Károly" },
                 Actors = new List<Actor>()
                {
                    new Actor(){
                   ActorId = 1,
                   ActorName = "Ádám Kornél",

                    }
                },
                Roles = new List<Role>()
                {
                    new Role()
                    {
                    RoleID = 1,
                    ActorId = 1,
                    PlayId = 1,
                    Rolename = "Tankred Dorst",
                    },
                    new Role()
                    {
                    RoleID = 2,
                    ActorId = 1,
                    PlayId = 1,
                    Rolename = "Grass",
                    }
                }

            },


        }.AsQueryable());


            mockRole = new Mock<IRepository<Role>>();
            mockRole.Setup(m => m.ReadAll()).Returns(new List<Role>().AsQueryable());
            mockDirector = new Mock<IRepository<Director>>();
            mockDirector.Setup(m => m.ReadAll()).Returns(new List<Director>().AsQueryable());
            mockActor = new Mock<IRepository<Actor>>();
            mockActor.Setup(m => m.ReadAll()).Returns(new List<Actor>().AsQueryable());
            playLogic = new PlayLogic(mockPlay.Object);
            roleLogic = new RoleLogic(mockRole.Object);
            directorLogic = new DirectorLogic(mockDirector.Object);
            actorLogic = new ActorLogic(mockActor.Object);


        }

        [Test]
        public void MostActorsTest()
        {
            var actor = playLogic.MostActors();

            Assert.That(actor.ToArray()[0].Count == 2 && actor.ToArray()[0].PlayTitle == "Háry János");
        }
        [Test]
        public void FirstPlayWithActorTest()
        {
            var first = playLogic.FirstPlayWithActor();
            Assert.That(first.ToList()[0].date == DateTime.Parse("1883.02.19") && first.ToArray()[0].name == "Ádám Kornél");
        }

        [Test]
        public void MostIncomeWithActorTest()
        {
            var most = playLogic.MostIncomeWithActor();
            Assert.That(most.ToArray()[0].money() == 2000 && most.ToArray()[0].Actor == "Ádám Kornél");
        }
        [Test]
        public void directorWithPlayTest()
        {
            var director = playLogic.directorWithPlay();
            Assert.That(director.ToArray()[0].dname() == "Goldmark Károly");
        }

        [Test]
        public void MostRolesTest()
        {
            var roles = playLogic.MostRoles();
            Assert.That(roles.ToArray()[0].Title == "Háry Péter" && roles.ToArray()[0].Roles == 2);
        }

        [Test]

        public void Playcreatetest()
        {
            var noExceptionThrown = true;

            try
            {
                playLogic.Create(new Play() { Title = "asd" });
            }
            catch (Exception)
            {
                noExceptionThrown = false;
            }
            finally
            {
                Assert.IsTrue(noExceptionThrown);
            }


        }

        [Test]
        public void Directorcreatetest()
        {
            var noExceptionThrown = true;

            try
            {
                directorLogic.Create(new Director() { Name = "asd" });
            }
            catch (Exception)
            {
                noExceptionThrown = false;
            }
            finally
            {
                Assert.IsTrue(noExceptionThrown);
            }
        }
        [Test]
        public void Rolecreatetest()
        {
            var noExceptionThrown = true;

            try
            {
                roleLogic.Create(new Role() { Rolename = "asd" });
            }
            catch (Exception)
            {
                noExceptionThrown = false;
            }
            finally
            {
                Assert.IsTrue(noExceptionThrown);
            }


        }
        [Test]
        public void Actorcreatetest()
        {
            var noExceptionThrown = true;

            try
            {
                actorLogic.Create(new Actor() { ActorName = "asd" });
            }
            catch (Exception)
            {
                noExceptionThrown = false;
            }
            finally
            {
                Assert.IsTrue(noExceptionThrown);
            }


        }

        [Test]
        public void PlaysTest()
        {
            var count = playLogic.Plays();
            Assert.That(count[0] == 4);
        }

    }
    }
