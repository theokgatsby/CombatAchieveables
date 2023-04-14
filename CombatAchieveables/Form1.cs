using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// ################
// # Version 1.2  #
// # 04 / 07 / 23 #
// ################

namespace CombatAchieveables
{
    public partial class Form1 : Form
    {
        public static List<Task> TaskList = new List<Task>();
        static string EasyList = "Aberrant Spectre\tNoxious Foe\tKill an Aberrant Spectre.\tKill Count\r\nBarrows\tBarrows Novice\tOpen the Barrows chest 10 times.\tKill Count\r\nBarrows\tDefence? What Defence?\tKill any Barrows Brother using only magical damage.\tRestriction\r\nBlack Dragon\tBig, Black and Fiery\tKill a Black Dragon.\tKill Count\r\nBloodveld\tThe Demonic Punching Bag\tKill a Bloodveld.\tKill Count\r\nBryophyta\tPreparation Is Key\tKill Bryophyta without suffering any poison damage.\tPerfection\r\nBryophyta\tFighting as Intended II\tKill Bryophyta on a free to play world.\tRestriction\r\nBryophyta\tBryophyta Novice\tKill Bryophyta once.\tKill Count\r\nBryophyta\tA Slow Death\tKill Bryophyta with either poison or venom being the final source of damage.\tRestriction\r\nBryophyta\tProtection from Moss\tKill Bryophyta with the Protect from Magic prayer active.\tMechanical\r\nDeranged Archaeologist\tDeranged Archaeologist Novice\tKill the Deranged Archaeologist 10 times.\tKill Count\r\nFire Giant\tThe Walking Volcano\tKill a Fire Giant.\tKill Count\r\nGiant Mole\tGiant Mole Novice\tKill the Giant Mole 10 times.\tKill Count\r\nGreater Demon\tA Greater Foe\tKill a Greater Demon.\tKill Count\r\nGreater Demon\tNot So Great After All\tFinish off a Greater Demon with a demonbane weapon.\tRestriction\r\nHellhound\tA Demon's Best Friend\tKill a Hellhound.\tKill Count\r\nKing Black Dragon\tKing Black Dragon Novice\tKill the King Black Dragon 10 times.\tKill Count\r\nLizardman Shaman\tA Scaley Encounter\tKill a Lizardman Shaman.\tKill Count\r\nLizardman Shaman\tShayzien Protector\tKill a Lizardman Shaman in Molch which has not dealt damage to anyone. (excluding its Spawns)\tPerfection\r\nGiants\tInto the Den of Giants\tKill a Hill Giant, Moss Giant and Fire Giant in the Giant Cave within the Shayzien region.\tKill Count\r\nObor\tObor Novice\tKill Obor once.\tKill Count\r\nObor\tFighting as Intended\tKill Obor on a free to play world.\tRestriction\r\nObor\tSleeping Giant\tKill Obor whilst he is immobilized.\tMechanical\r\nSarachnis\tSarachnis Novice\tKill Sarachnis 10 times.\tKill Count\r\nTempoross\tMaster of Buckets\tExtinguish at least 5 fires during a single Tempoross fight.\tMechanical\r\nTempoross\tCalm Before the Storm\tRepair either a mast or a totem pole.\tMechanical\r\nTempoross\tFire in the Hole!\tAttack Tempoross from both sides by loading both cannons on both ships.\tMechanical\r\nTempoross\tTempoross Novice\tSubdue Tempoross 5 times.\tKill Count\r\nWintertodt\tHandyman\tRepair a brazier which has been destroyed by the Wintertodt.\tMechanical\r\nWintertodt\tCosy\tSubdue the Wintertodt with four pieces of warm equipment equipped.\tRestriction\r\nWintertodt\tMummy!\tHeal a pyromancer after they have fallen.\tMechanical\r\nWintertodt\tWintertodt Novice\tSubdue the Wintertodt 5 times.\tKill Count\r\nWyrm\tA Slithery Encounter\tKill a Wyrm.\tKill Count";
        static string MediumList = "Barrows\tPray for Success\tKill all six Barrows Brothers and loot the Barrows chest without taking any damage from any of the brothers.\tPerfection\r\nBarrows\tBarrows Champion\tOpen the Barrows chest 25 times.\tKill Count\r\nBarrows\tCan't Touch Me\tKill Dharok, Verac, Torag and Guthan without letting them attack you with melee.\tMechanical\r\nBrutal Black Dragon\tBrutal, Big, Black and Firey\tKill a Brutal Black Dragon.\tKill Count\r\nBryophyta\tBryophyta Champion\tKill Bryophyta 5 times.\tKill Count\r\nBryophyta\tQuick Cutter\tKill all 3 of Bryophyta's growthlings within 3 seconds of the first one dying.\tMechanical\r\nChaos Fanatic\tChaos Fanatic Champion\tKill the Chaos Fanatic 10 times.\tKill Count\r\nChaos Fanatic\tSorry, What Was That?\tKill the Chaos Fanatic without anyone being hit by his explosion attack.\tPerfection\r\nCrazy Archaeologist\tI'd Rather Not Learn\tKill the Crazy Archaeologist without anyone being hit by his \"Rain of Knowledge\" attack.\tPerfection\r\nCrazy Archaeologist\tCrazy Archaeologist Champion\tKill the Crazy Archaeologist 10 times.\tKill Count\r\nCrazy Archaeologist\tMage of the Ruins\tKill the Crazy Archaeologist with only magical attacks.\tMechanical\r\nDagannoth Prime\tDagannoth Prime Champion\tKill Dagannoth Prime 10 times.\tKill Count\r\nDagannoth Rex\tDagannoth Rex Champion\tKill Dagannoth Rex 10 times.\tKill Count\r\nDagannoth Rex\tA Frozen King\tKill Dagannoth Rex whilst he is immobilized.\tMechanical\r\nDagannoth Supreme\tDagannoth Supreme Champion\tKill Dagannoth Supreme 10 times.\tKill Count\r\nDeranged Archaeologist\tI'd Rather Be Illiterate\tKill the Deranged Archaeologist without anyone being hit by his \"Learn to Read\" attack.\tPerfection\r\nDeranged Archaeologist\tMage of the Swamp\tKill the Deranged Archaeologist with only magical attacks.\tMechanical\r\nDeranged Archaeologist\tDeranged Archaeologist Champion\tKill the Deranged Archaeologist 25 times.\tKill Count\r\nGargoyle\tA Smashing Time\tKill a Gargoyle.\tKill Count\r\nGiant Mole\tGiant Mole Champion\tKill the Giant mole 25 times.\tKill Count\r\nGiant Mole\tAvoiding Those Little Arms\tKill the Giant Mole without her damaging anyone.\tPerfection\r\nKing Black Dragon\tKing Black Dragon Champion\tKill the King Black Dragon 25 times.\tKill Count\r\nKing Black Dragon\tClaw Clipper\tKill the King Black Dragon with the Protect from Melee prayer activated.\tMechanical\r\nKing Black Dragon\tAntifire Protection\tKill the King Black Dragon with an antifire potion active and an antidragon shield equipped.\tRestriction\r\nKing Black Dragon\tHide Penetration\tKill the King Black Dragon with a stab weapon.\tRestriction\r\nKurask\tMaster of Broad Weaponry\tKill a Kurask.\tKill Count\r\nN/A\tSit Back and Relax\tDeal 100 damage to creatures using undead thralls.\tMechanical\r\nObor\tBack to the Wall\tKill Obor without being pushed back more than one square by his knockback attack.\tMechanical\r\nObor\tSquashing the Giant\tKill Obor without taking any damage off prayer.\tPerfection\r\nObor\tObor Champion\tKill Obor 5 times.\tKill Count\r\nSarachnis\tNewspaper Enthusiast\tKill Sarachnis with a crush weapon.\tRestriction\r\nSarachnis\tSarachnis Champion\tKill Sarachnis 25 times.\tKill Count\r\nSkeletal Wyvern\tA Frozen Foe from the Past\tKill a Skeletal Wyvern\tKill Count\r\nSkotizo\tDemonbane Weaponry\tKill Skotizo with a demonbane weapon equipped.\tRestriction\r\nSkotizo\tSkotizo Champion\tKill Skotizo once.\tKill Count\r\nSkotizo\tDemonic Weakening\tKill Skotizo with no altars active.\tMechanical\r\nTempoross\tTempoross Champion\tSubdue Tempoross 10 times.\tKill Count\r\nTempoross\tThe Lone Angler\tSubdue Tempoross alone without getting hit by any fires, torrents or waves.\tPerfection\r\nWintertodt\tLeaving No One Behind\tSubdue the Wintertodt without any of the Pyromancers falling.\tRestriction\r\nWintertodt\tCan We Fix It?\tSubdue the Wintertodt without allowing all 4 braziers to be broken at the same time.\tPerfection\r\nWintertodt\tWintertodt Champion\tSubdue the Wintertodt 10 times.\tKill Count";
        static string HardList = "Abyssal Sire\tAbyssal Adept\tKill the Abyssal Sire 20 times.\tKill Count\r\nAbyssal Sire\tDon't Whip Me\tKill the Abyssal Sire without being hit by any external tentacles.\tMechanical\r\nAbyssal Sire\tDon't Stop Moving\tKill the Abyssal Sire without taking damage from any miasma pools.\tPerfection\r\nAbyssal Sire\tThey Grow Up Too Fast\tKill the Abyssal Sire without letting any Scion mature.\tMechanical\r\nBarrows\tFaithless Crypt Run\tKill all six Barrows Brothers and loot the Barrows chest without ever having more than 0 prayer points.\tRestriction\r\nBarrows\tJust Like That\tKill Karil using only damage dealt by special attacks.\tRestriction\r\nCallisto\tCallisto Adept\tKill Callisto 10 times.\tKill Count\r\nChaos Elemental\tChaos Elemental Adept\tKill the Chaos Elemental 10 times.\tKill Count\r\nChaos Elemental\tThe Flincher\tKill the Chaos Elemental without taking any damage from it's attacks.\tPerfection\r\nChaos Elemental\tHoarder\tKill the Chaos Elemental without it unequipping any of your items.\tMechanical\r\nChaos Fanatic\tPraying to the Gods\tKill the Chaos Fanatic 10 times without drinking any potion which restores prayer or leaving the Wilderness.\tRestriction\r\nChaos Fanatic\tChaos Fanatic Adept\tKill the Chaos Fanatic 25 times.\tKill Count\r\nCommander Zilyana\tCommander Showdown\tFinish off Commander Zilyana while all of her bodyguards are dead.\tMechanical\r\nCommander Zilyana\tCommander Zilyana Adept\tKill Commander Zilyana 50 times.\tKill Count\r\nCrazy Archaeologist\tCrazy Archaeologist Adept\tKill the Crazy Archaeologist 25 times.\tKill Count\r\nDagannoth Prime\tDagannoth Prime Adept\tKill Dagannoth Prime 25 times.\tKill Count\r\nDagannoth Rex\tDagannoth Rex Adept\tKill Dagannoth Rex 25 times.\tKill Count\r\nDagannoth Supreme\tDagannoth Supreme Adept\tKill Dagannoth Supreme 25 times.\tKill Count\r\nGeneral Graardor\tGeneral Graardor Adept\tKill General Graardor 50 times.\tKill Count\r\nGeneral Graardor\tGeneral Showdown\tFinish off General Graardor whilst all of his bodyguards are dead.\tMechanical\r\nGeneral Graardor\tOurg Freezer\tKill General Graardor whilst he is immobilized.\tMechanical\r\nGiant Mole\tWhy Are You Running?\tKill the Giant Mole without her burrowing more than 2 times.\tMechanical\r\nGiant Mole\tWhack-a-Mole\tKill the Giant Mole within 10 seconds of her resurfacing.\tMechanical\r\nGrotesque Guardians\tStatic Awareness\tKill the Grotesque Guardians without being hit by any lightning attacks.\tMechanical\r\nGrotesque Guardians\tPrison Break\tKill the Grotesque Guardians without taking damage from Dusk's prison attack.\tMechanical\r\nGrotesque Guardians\tDon't Look at the Eclipse\tKill the Grotesque Guardians without taking damage from Dusk's blinding attack.\tMechanical\r\nGrotesque Guardians\tGranite Footwork\tKill the Grotesque Guardians without taking damage from Dawn's rockfall attack.\tMechanical\r\nGrotesque Guardians\tHeal No More\tKill the Grotesque Guardians without letting Dawn receive any healing from her orbs.\tMechanical\r\nGrotesque Guardians\tGrotesque Guardians Adept\tKill the Grotesque Guardians 25 times.\tKill Count\r\nHespori\tHespori Adept\tKill Hespori 5 times.\tKill Count\r\nHespori\tHesporisn't\tFinish off Hespori with a special attack.\tMechanical\r\nHespori\tWeed Whacker\tKill all of Hesporis flowers within 5 seconds.\tMechanical\r\nK'ril Tsutsaroth\tDemonic Showdown\tFinish off K'ril Tsutsaroth whilst all of his bodyguards are dead.\tMechanical\r\nK'ril Tsutsaroth\tDemonbane Weaponry II\tFinish off K'ril Tsutsaroth with a demonbane weapon.\tRestriction\r\nK'ril Tsutsaroth\tK'ril Tsutsaroth Adept\tKill K'ril Tsutsaroth 50 times.\tKill Count\r\nK'ril Tsutsaroth\tYarr No More\tReceive kill-credit for K'ril Tsutsaroth without him using his special attack.\tMechanical\r\nKalphite Queen\tKalphite Queen Adept\tKill the Kalphite Queen 25 times.\tKill Count\r\nKalphite Queen\tChitin Penetrator\tKill the Kalphite Queen while her defence was last lowered by you.\tMechanical\r\nKing Black Dragon\tWho Is the King Now?\tKill The King Black Dragon 10 times in a private instance without leaving the instance.\tStamina\r\nKraken\tUnnecessary Optimization\tKill the Kraken after killing all four tentacles.\tMechanical\r\nKraken\tKrakan't Hurt Me\tKill the Kraken 25 times in a private instance without leaving the room.\tStamina\r\nKraken\tKraken Adept\tKill the Kraken 20 times.\tKill Count\r\nKree'arra\tAirborne Showdown\tFinish off Kree'arra whilst all of his bodyguards are dead.\tMechanical\r\nKree'arra\tKree'arra Adept\tKill Kree'arra 50 times.\tKill Count\r\nPhantom Muspah\tPhantom Muspah Adept\tKill the Phantom Muspah.\tKill Count\r\nSarachnis\tInspect Repellent\tKill Sarachnis without her dealing damage to anyone.\tPerfection\r\nSarachnis\tReady to Pounce\tKill Sarachnis without her using her range attack twice in a row.\tMechanical\r\nScorpia\tGuardians No More\tKill Scorpia without killing her guardians.\tRestriction\r\nScorpia\tI Can't Reach That\tKill Scorpia without taking any damage from her.\tPerfection\r\nScorpia\tScorpia Adept\tKill Scorpia 10 times.\tKill Count\r\nSkotizo\tSkotizo Adept\tKill Skotizo 5 times.\tKill Count\r\nTempoross\tDress Like You Mean It\tSubdue Tempoross while wearing any variation of the angler outfit.\tRestriction\r\nTempoross\tWhy Cook?\tSubdue Tempoross, getting rewarded with 10 reward permits from a single Tempoross fight.\tMechanical\r\nThe Nightmare\tNightmare Adept\tKill The Nightmare once.\tKill Count\r\nToB: Entry Mode\tToB: SM Adept\tComplete the ToB: Entry Mode 1 time.\tKill Count\r\nToA: Entry Mode\tConfident Raider\tComplete a ToA raid at level 100 or above.\tRestriction\r\nToA: Entry Mode\tNovice Tomb Explorer\tComplete the ToA in Entry mode (or above) once.\tKill Count\r\nToA: Entry Mode\tMovin' on up\tComplete a ToA raid at level 50 or above.\tRestriction\r\nToA: Entry Mode\tNovice Tomb Looter\tComplete the ToA in Entry mode (or above) 25 times.\tKill Count\r\nVenenatis\tVenenatis Adept\tKill Venenatis 10 times.\tKill Count\r\nVet'ion\tVet'ion Adept\tKill Vet'ion 10 times.\tKill Count\r\nWintertodt\tWhy Fletch?\tSubdue the Wintertodt after earning 3000 or more points.\tStamina\r\nZulrah\tZulrah Adept\tKill Zulrah 25 times.\tKill Count";
        static string EliteList = "Abyssal Sire\tPerfect Sire\tKill the Abyssal Sire without taking damage from the external tentacles, miasma pools, explosion or damage from the Abyssal Sire without praying the appropriate protection prayer.\tPerfection\r\nAbyssal Sire\tAbyssal Veteran\tKill the Abyssal Sire 50 times.\tKill Count\r\nAbyssal Sire\tDemonic Rebound\tUse the Vengeance spell to reflect the damage from the Abyssal Sire's explosion back to him.\tMechanical\r\nAbyssal Sire\tRespiratory Runner\tKill the Abyssal Sire after only stunning him once.\tMechanical\r\nAlchemical Hydra\tAlchemical Veteran\tKill the Alchemical Hydra 75 times.\tKill Count\r\nBasilisk Knight\tReflecting on This Encounter\tKill a Basilisk Knight.\tKill Count\r\nCallisto\tCallisto Veteran\tKill Callisto 20 times.\tKill Count\r\nCerberus\tGhost Buster\tKill Cerberus after successfully negating 6 or more attacks from Summoned Souls.\tMechanical\r\nCerberus\tUnrequired Antifire\tKill Cerberus without taking damage from any lava pools.\tPerfection\r\nCerberus\tCerberus Veteran\tKill Cerberus 75 times.\tKill Count\r\nCerberus\tAnti-Bite Mechanics\tKill Cerberus without taking any melee damage.\tPerfection\r\nCoX\tRedemption Enthusiast\tKill the Abyssal Portal without forcing Vespula to land.\tMechanical\r\nCoX\tPerfectly Balanced\tKill the Vanguards without them resetting their health.\tMechanical\r\nCoX\tDancing with Statues\tReceive kill-credit for a Stone Guardian without taking damage from falling rocks.\tPerfection\r\nCoX\tShayzien Specialist\tReceive kill-credit for a Lizardman Shaman without taking damage from any shamans in the room.\tPerfection\r\nCoX\tCryo No More\tReceive kill-credit for the Ice Demon without taking any damage.\tPerfection\r\nCoX\tCoX Veteran\tComplete the CoX 25 times.\tKill Count\r\nCoX\tMutta-diet\tKill the Muttadile without letting her or her baby recover hitpoints from the meat tree.\tMechanical\r\nCoX\tBlizzard Dodger\tReceive kill-credit for the Ice Demon without activating the Protect from Range prayer.\tRestriction\r\nCoX\tUndying Raid Team\tComplete a CoX raid without anyone dying.\tPerfection\r\nCoX\tKill It with Fire\tFinish off the Ice Demon with a fire spell.\tRestriction\r\nCoX\tTogether We'll Fall\tKill the Vanguards within 10 seconds of the first one dying.\tMechanical\r\nCoX: Challenge Mode\tDust Seeker\tComplete a CoX Challenge mode raid in the target time.\tSpeed\r\nChaos Elemental\tChaos Elemental Veteran\tKill the Chaos Elemental 25 times.\tKill Count\r\nCommander Zilyana\tCommander Zilyana Veteran\tKill Commander Zilyana 100 times.\tKill Count\r\nCommander Zilyana\tReminisce\tKill Commander Zilyana in a private instance with melee only.\tRestriction\r\nCorporeal Beast\tChicken Killer\tKill the Corporeal Beast solo.\tRestriction\r\nCorporeal Beast\tHot on Your Feet\tKill the Corporeal Beast without anyone killing the dark core or taking damage from the dark core.\tPerfection\r\nCorporeal Beast\tCorporeal Beast Veteran\tKill the Corporeal Beast 25 times.\tKill Count\r\nCorporeal Beast\tFinding the Weak Spot\tFinish off the Corporeal Beast with a Crystal Halberd special attack.\tRestriction\r\nCorrupted Hunllef\t3, 2, 1 - Mage\tKill the Corrupted Hunllef without taking damage off prayer.\tPerfection\r\nCorrupted Hunllef\tCorrupted Gauntlet Veteran\tComplete the Corrupted Gauntlet 5 times.\tKill Count\r\nCrystalline Hunllef\tGauntlet Veteran\tComplete the Gauntlet 5 times.\tKill Count\r\nCrystalline Hunllef\tWolf Puncher\tKill the Crystalline Hunllef without making more than one attuned weapon.\tRestriction\r\nCrystalline Hunllef\t3, 2, 1 - Range\tKill the Crystalline Hunllef without taking damage off prayer.\tPerfection\r\nCrystalline Hunllef\tCrystalline Warrior\tKill the Crystalline Hunllef with a full set of perfected armour equipped.\tRestriction\r\nCrystalline Hunllef\tEgniol Diet\tKill the Crystalline Hunllef without making an egniol potion within the Gauntlet.\tRestriction\r\nDagannoth Prime\tFrom One King to Another\tKill Prime using a Rune Thrownaxe special attack, bounced off Dagannoth Rex.\tMechanical\r\nDagannoth Prime\tDeath to the Seer King\tKill Dagannoth Prime whilst under attack by Dagannoth Supreme and Dagannoth Rex.\tMechanical\r\nDagannoth Rex\tDeath to the Warrior King\tKill Dagannoth Rex whilst under attack by Dagannoth Supreme and Dagannoth Prime.\tMechanical\r\nDagannoth Rex\tToppling the Diarchy\tKill Dagannoth Rex and one other Dagannoth king at the exact same time.\tMechanical\r\nDagannoth Supreme\tDeath to the Archer King\tKill Dagannoth Supreme whilst under attack by Dagannoth Prime and Dagannoth Rex.\tMechanical\r\nDagannoth Supreme\tRapid Succession\tKill all three Dagannoth Kings within 9 seconds of the first one.\tMechanical\r\nDemonic Gorilla\tIf Gorillas Could Fly\tKill a Demonic Gorilla.\tKill Count\r\nDemonic Gorilla\tHitting Them Where It Hurts\tFinish off a Demonic Gorilla with a demonbane weapon.\tRestriction\r\nFragment of Seren\tFragment of Seren Speed-Trialist\tKill The Fragment of Seren in less than 4 minutes.\tSpeed\r\nGalvek\tGalvek Speed-Trialist\tKill Galvek in less than 3 minutes.\tSpeed\r\nGeneral Graardor\tOurg Freezer II\tKill General Graardor without him attacking any players.\tMechanical\r\nGeneral Graardor\tGeneral Graardor Veteran\tKill General Graardor 100 times.\tKill Count\r\nGiant Mole\tHard Hitter\tKill the Giant Mole with 4 or fewer instances of damage.\tMechanical\r\nGlough\tGlough Speed-Trialist\tKill Glough in less than 2 minutes and 30 seconds.\tSpeed\r\nGrotesque Guardians\tGrotesque Guardians Veteran\tKill the Grotesque Guardians 50 times.\tKill Count\r\nGrotesque Guardians\tFrom Dusk...\tKill the Grotesque Guardians 10 times without leaving the instance.\tStamina\r\nGrotesque Guardians\tGrotesque Guardians Speed-Trialist\tKill the Grotesque Guardians in less than 2 minutes.\tSpeed\r\nGrotesque Guardians\tDone before Dusk\tKill the Grotesque Guardians before Dusk uses his prison attack for a second time.\tMechanical\r\nGrotesque Guardians\tPerfect Grotesque Guardians\tKill the Grotesque Guardians whilst completing the \"Don't look at the eclipse\", \"Prison Break\", \"Granite Footwork\", \"Heal no more\", \"Static Awareness\" and \"Done before dusk\" tasks.\tPerfection\r\nHespori\tPlant-Based Diet\tKill Hespori without losing any prayer points.\tRestriction\r\nHespori\tHespori Speed-Trialist\tKill the Hespori in less than 48 seconds.\tSpeed\r\nK'ril Tsutsaroth\tThe Bane of Demons\tDefeat K'ril Tsutsaroth in a private instance using only demonbane spells.\tMechanical\r\nK'ril Tsutsaroth\tK'ril Tsutsaroth Veteran\tKill K'ril Tsutsaroth 100 times.\tKill Count\r\nK'ril Tsutsaroth\tDemonic Defence\tKill K'ril Tsutsaroth in a private instance without taking any of his melee hits.\tPerfection\r\nKalphite Queen\tKalphite Queen Veteran\tKill the Kalphite Queen 50 times.\tKill Count\r\nKalphite Queen\tInsect Deflection\tKill the Kalphite Queen by using the Vengeance spell as the finishing blow.\tMechanical\r\nKalphite Queen\tPrayer Smasher\tKill the Kalphite Queen using only the Verac's Flail as a weapon.\tRestriction\r\nKraken\tTen-tacles\tKill the Kraken 50 times in a private instance without leaving the room.\tStamina\r\nKree'arra\tKree'arra Veteran\tKill Kree'arra 100 times.\tKill Count\r\nNex\tNex Survivors\tKill Nex without anyone dying.\tRestriction\r\nNex\tNex Veteran\tKill Nex once.\tKill Count\r\nPhantom Muspah\tPhantom Muspah Veteran\tKill the Phantom Muspah 25 times.\tKill Count\r\nPhantom Muspah\tPhantom Muspah Speed-Trialist\tKill the Phantom Muspah in less than 3 minutes without a slayer task.\tSpeed\r\nPhantom Muspah\tVersatile Drainer\tDrain the Phantom Muspah's Prayer with three different sources in one kill.\tMechanical\r\nPhantom Muspah\tCan't Escape\tKill the Phantom Muspah without running.\tRestriction\r\nPhosani\tPhosani's Veteran\tKill Phosani once.\tKill Count\r\nScorpia\tScorpia Veteran\tKill Scorpia 25 times.\tKill Count\r\nSkotizo\tDemon Evasion\tKill Skotizo without taking any damage.\tPerfection\r\nSkotizo\tUp for the Challenge\tKill Skotizo without equipping a demonbane weapon.\tRestriction\r\nThe Mimic\tMimic Veteran\tKill the Mimic once.\tKill Count\r\nThe Nightmare\tNightmare Veteran\tKill The Nightmare 25 times.\tKill Count\r\nThe Nightmare\tExplosion!\tKill two Husks at the same time.\tMechanical\r\nThe Nightmare\tNightmare (5-Scale) Speed-Trialist\tDefeat the Nightmare (5-scale) in less than 5 minutes.\tSpeed\r\nThe Nightmare\tNightmare (Solo) Speed-Trialist\tDefeat the Nightmare (Solo) in less than 23 minutes.\tSpeed\r\nThe Nightmare\tSleep Tight\tKill the Nightmare solo.\tRestriction\r\nToB\tToB Veteran\tComplete the ToB 25 times.\tKill Count\r\nToB: Entry Mode\tChally Time\tDefeat the Pestilent Bloat in the ToB: Entry Mode by using a crystal halberd special attack as your final attack.\tMechanical\r\nToB: Entry Mode\tNylocas, On the Rocks\tIn the ToB: Entry Mode, freeze any 4 Nylocas with a single Ice Barrage spell.\tMechanical\r\nToB: Entry Mode\tThey Won't Expect This\tIn the ToB: Entry Mode, enter the Pestilent Bloat room from the opposite side.\tMechanical\r\nToB: Entry Mode\tAppropriate Tools\tDefeat the Pestilent Bloat in the ToB: Entry Mode with everyone having a salve amulet equipped.\tMechanical\r\nToB: Entry Mode\tAnticoagulants\tDefeat the Maiden of Sugadinti in the ToB: Entry Mode without letting any bloodspawn live for longer than 10 seconds.\tMechanical\r\nToB: Entry Mode\tJust To Be Safe\tDefeat Sotetseg in the ToB: Entry Mode after having split the big ball with your entire team. This must be done with a group size of at least 2.\tMechanical\r\nToB: Entry Mode\tAttack, Step, Wait\tSurvive Verzik Vitur's second phase in the ToB: Entry Mode without anyone getting bounced by Verzik.\tMechanical\r\nToB: Entry Mode\tNo-Pillar\tSurvive Verzik Vitur's pillar phase in the ToB: Entry Mode without losing a single pillar.\tMechanical\r\nToB: Entry Mode\tPass It On\tIn the ToB: Entry Mode, successfully pass on the green ball to a team mate.\tMechanical\r\nToB: Entry Mode\tDon't Look at Me!\tKill Xarpus in the ToB: Entry Mode without him reflecting any damage to anyone.\tMechanical\r\nThermy\tHazard Prevention\tKill the Thermy without it hitting anyone.\tPerfection\r\nThermy\tThermonuclear Veteran\tKill the Thermy 20 times.\tKill Count\r\nThermy\tSpec'd Out\tKill the Thermy using only special attacks.\tRestriction\r\nToA\tTomb Explorer\tComplete the ToA once.\tKill Count\r\nToA\tI'm in a rush\tDefeat Ba-Ba after destroying four or fewer rolling boulders in total without dying yourself.\tMechanical\r\nToA\tDropped the ball\tDefeat Akkha without dropping any materialising orbs and without dying yourself.\tMechanical\r\nToA\tHelpful spirit who?\tComplete the ToA without using any supplies from the Helpful Spirit and without anyone dying. Honey locusts are included in this restriction.\tRestriction\r\nToA\tDown Do Specs\tDefeat the Wardens after staggering the boss a maximum of twice during phase two, without dying yourself.\tMechanical\r\nToA\tPerfect Crondis\tComplete the Crondis room without letting a crocodile get to the tree, without anyone losing water from their container and in under one minute.\tPerfection\r\nToA\tNo skipping allowed\tDefeat Ba-Ba after only attacking the non-weakened boulders in the rolling boulder phase, without dying yourself. The Boulderdash invocation must be activated.\tMechanical\r\nToA\tHardcore Tombs\tComplete the ToA solo without dying.\tPerfection\r\nToA\tHardcore Raiders\tComplete the ToA in a group of two or more without anyone dying.\tPerfection\r\nToA\tPerfect Het\tComplete the Het room without taking any damage from the light beam and orbs. You must destroy the core after one exposure.\tPerfection\r\nToA\tPerfect Apmeken\tComplete the Apmeken room in a group of two or more, without anyone allowing any dangers to trigger, standing in venom or being hit by a volatile baboon. You must complete this room in less than three minutes.\tPerfection\r\nToA: Entry Mode\tNovice Tomb Raider\tComplete the ToA in Entry mode (or above) 50 times.\tKill Count\r\nToA: Expert Mode\tExpert Tomb Explorer\tComplete the ToA (Expert mode) once.\tKill Count\r\nTzHaar Challenges\tTzHaar-Ket-Rak's Speed-Trialist\tComplete TzHaar-Ket-Rak's first challenge in less than 45 seconds.\tSpeed\r\nTzHaar Challenges\tFacing Jad Head-on III\tComplete TzHaar-Ket-Rak's second challenge with only melee.\tRestriction\r\nTzHaar Challenges\tThe II Jad Challenge\tComplete TzHaar-Ket-Rak's second challenge.\tKill Count\r\nTzKal-Zuk\tHalf-Way There\tKill a Jal-Zek within the Inferno.\tKill Count\r\nTzTok-Jad\tFight Caves Veteran\tComplete the Fight Caves once.\tKill Count\r\nTzTok-Jad\tA Near Miss!\tComplete the Fight Caves after surviving a hit from TzTok-Jad without praying.\tMechanical\r\nTzTok-Jad\tFacing Jad Head-on\tComplete the Fight Caves with only melee.\tRestriction\r\nVenenatis\tVenenatis Veteran\tKill Venenatis 20 times.\tKill Count\r\nVet'ion\tVet'eran\tKill Vet'ion 20 times.\tKill Count\r\nVorkath\tVorkath Veteran\tKill Vorkath 50 times.\tKill Count\r\nVorkath\tStick 'em With the Pointy End\tKill Vorkath using melee weapons only.\tRestriction\r\nVorkath\tZombie Destroyer\tKill Vorkath's zombified spawn without using crumble undead.\tRestriction\r\nZalcano\tTeam Player\tReceive imbued tephra from a golem.\tMechanical\r\nZalcano\tThe Spurned Hero\tKill Zalcano as the player who has dealt the most damage to her.\tMechanical\r\nZalcano\tZalcano Veteran\tKill Zalcano 25 times.\tKill Count\r\nZalcano\tPerfect Zalcano\tKill Zalcano 5 times in a row without leaving or getting hit by the following: Falling rocks, rock explosions, Zalcano powering up, or standing in a red symbol.\tPerfection\r\nZulrah\tSnake. Snake!? Snaaaaaake!\tKill 3 Snakelings simultaneously.\tMechanical\r\nZulrah\tSnake Rebound\tKill Zulrah by using the Vengeance spell as the finishing blow.\tMechanical\r\nZulrah\tZulrah Speed-Trialist\tKill Zulrah in less than 1 minute 20 seconds, without a slayer task.\tSpeed\r\nZulrah\tZulrah Veteran\tKill Zulrah 75 times.\tKill Count";
        static string MasterList = "Alchemical Hydra\tLightning Lure\tKill the Alchemical Hydra without being hit by the lightning attack.\tMechanical\r\nAlchemical Hydra\tAlchemical Speed-Chaser\tKill the Alchemical Hydra in less than 1 minute 45 seconds.\tSpeed\r\nAlchemical Hydra\tAlcleanical Hydra\tKill the Alchemical Hydra without taking any damage.\tPerfection\r\nAlchemical Hydra\tMixing Correctly\tKill the Alchemical Hydra without empowering it.\tMechanical\r\nAlchemical Hydra\tUnrequired Antipoisons\tKill the Alchemical Hydra without being hit by the acid pool attack.\tMechanical\r\nAlchemical Hydra\tAlchemical Master\tKill the Alchemical Hydra 150 times.\tKill Count\r\nAlchemical Hydra\tWorking Overtime\tKill the Alchemical Hydra 15 times without leaving the room.\tStamina\r\nAlchemical Hydra\tThe Flame Skipper\tKill the Alchemical Hydra without letting it spawn a flame wall attack.\tMechanical\r\nAlchemical Hydra\tDon't Flame Me\tKill the Alchemical Hydra without being hit by the flame wall attack.\tMechanical\r\nCerberus\tArooo No More\tKill Cerberus without any of the Summoned Souls being spawned.\tMechanical\r\nCerberus\tCerberus Master\tKill Cerberus 150 times.\tKill Count\r\nCoX\tPerfect Olm (Solo)\tKill the Great Olm in a solo raid without taking damage from any of the following: Teleport portals, Fire Walls, Healing pools, Crystal Bombs, Crystal Burst or Prayer Orbs. You also cannot let his claws regenerate or take damage from the same acid pool back to back.\tPerfection\r\nCoX\tCoX (Solo) Speed-Chaser\tComplete a CoX (Solo) in less than 21 minutes.\tSpeed\r\nCoX\tCoX (5-Scale) Speed-Chaser\tComplete a CoX (5-scale) in less than 15 minutes.\tSpeed\r\nCoX\tPutting It Olm on the Line\tComplete a CoX solo raid with more than 40,000 points.\tMechanical\r\nCoX\tPlaying with Lasers\tClear the Crystal Crabs room without wasting an orb after the first crystal has been activated.\tPerfection\r\nCoX\tCoX (Trio) Speed-Chaser\tComplete a CoX (Trio) in less than 16 minutes and 30 seconds.\tSpeed\r\nCoX\tNo Time for Death\tClear the Tightrope room without Killing any Deathly Mages or Deathly Rangers.\tMechanical\r\nCoX\tCoX Master\tComplete the CoX 75 times.\tKill Count\r\nCoX\tPerfect Olm (Trio)\tKill the Great Olm in a trio raid without any team member taking damage from any of the following: Teleport portals, Fire Walls, Healing pools, Crystal Bombs, Crystal Burst or Prayer Orbs. You also cannot let his claws regenerate or take damage from the same acid pool back to back.\tPerfection\r\nCoX\tAnvil No More\tKill Tekton before he returns to his anvil for a second time after the fight begins.\tMechanical\r\nCoX\tUndying Raider\tComplete a CoX solo raid without dying.\tPerfection\r\nCoX\tStop Drop and Roll\tKill Vasa Nistirio before he performs his teleport attack for the second time.\tMechanical\r\nCoX\tA Not So Special Lizard\tKill the Great Olm in a solo raid without letting him use any of the following special attacks in his second to last phase: Crystal Burst, Lightning Walls, Teleportation Portals or left-hand autohealing.\tMechanical\r\nCoX\tBlind Spot\tKill Tekton without taking any damage.\tPerfection\r\nCoX: Challenge Mode\tImmortal Raider\tComplete a CoX Challenge mode (Solo) raid without dying.\tPerfection\r\nCoX: Challenge Mode\tCoX: CM (5-Scale) Speed-Chaser\tComplete a CoX: Challenge Mode (5-scale) in less than 30 minutes.\tSpeed\r\nCoX: Challenge Mode\tCoX: CM (Solo) Speed-Chaser\tComplete a CoX: Challenge Mode (Solo) in less than 45 minutes.\tSpeed\r\nCoX: Challenge Mode\tImmortal Raid Team\tComplete a CoX: Challenge mode raid without anyone dying.\tPerfection\r\nCoX: Challenge Mode\tCoX: CM Master\tComplete the CoX: Challenge Mode 10 times.\tKill Count\r\nCoX: Challenge Mode\tCoX: CM (Trio) Speed-Chaser\tComplete a CoX: Challenge Mode (Trio) in less than 35 minutes.\tSpeed\r\nCommander Zilyana\tMoving Collateral\tKill Commander Zilyana in a private instance without attacking her directly.\tRestriction\r\nCorporeal Beast\tCorporeal Beast Master\tKill the Corporeal Beast 50 times.\tKill Count\r\nCorrupted Hunllef\tCorrupted Gauntlet Master\tComplete the Corrupted Gauntlet 10 times.\tKill Count\r\nCorrupted Hunllef\tCorrupted Warrior\tKill the Corrupted Hunllef with a full set of perfected corrupted armour equipped.\tRestriction\r\nCorrupted Hunllef\tDefence Doesn't Matter II\tKill the Corrupted Hunllef without making any armour within the Corrupted Gauntlet.\tRestriction\r\nCorrupted Hunllef\tPerfect Corrupted Hunllef\tKill the Corrupted Hunllef without taking damage from: Tornadoes, Damaging Floor or Stomp Attacks. Also, do not take damage off prayer and do not attack the Corrupted Hunllef with the wrong weapon.\tPerfection\r\nCorrupted Hunllef\tCorrupted Gauntlet Speed-Chaser\tComplete a Corrupted Gauntlet in less than 7 minutes and 30 seconds.\tSpeed\r\nCrystalline Hunllef\tGauntlet Master\tComplete the Gauntlet 20 times.\tKill Count\r\nCrystalline Hunllef\tPerfect Crystalline Hunllef\tKill the Crystalline Hunllef without taking damage from: Tornadoes, Damaging Floor or Stomp Attacks. Also, do not take damage off prayer and do not attack the Crystalline Hunllef with the wrong weapon.\tPerfection\r\nCrystalline Hunllef\tGauntlet Speed-Chaser\tComplete the Gauntlet in less than 5 minutes.\tSpeed\r\nCrystalline Hunllef\tDefence Doesn't Matter\tKill the Crystalline Hunllef without making any armour within the Gauntlet.\tRestriction\r\nGrotesque Guardians\tPerfect Grotesque Guardians II\tKill the Grotesque Guardians 5 times in a row without leaving the instance, whilst completing the Perfect Grotesque Guardians task every time.\tPerfection\r\nGrotesque Guardians\tGrotesque Guardians Speed-Chaser\tKill the Grotesque Guardians in less than 1:40 minutes.\tSpeed\r\nGrotesque Guardians\t... 'til Dawn\tKill the Grotesque Guardians 20 times without leaving the instance.\tStamina\r\nHespori\tHespori Speed-Chaser\tKill the Hespori in less than 36 seconds.\tSpeed\r\nKraken\tOne Hundred Tentacles\tKill the Kraken 100 times in a private instance without leaving the room.\tStamina\r\nKree'arra\tSwoop No More\tKill Kree'arra in a private instance without taking any melee damage from the boss or his bodyguards.\tPerfection\r\nKree'arra\tCollateral Damage\tKill Kree'arra in a private instance without ever attacking him directly.\tMechanical\r\nNex\tContain this!\tKill Nex without anyone taking damage from any Ice special attack.\tMechanical\r\nNex\tNex Master\tKill Nex 25 times.\tKill Count\r\nNex\tShadows Move...\tKill Nex without anyone being hit by the Shadow Smash attack.\tMechanical\r\nNex\tNex Trio\tKill Nex with three or less players at the start of the fight.\tRestriction\r\nNex\tThere is no escape!\tKill Nex without anyone being hit by the Smoke Dash special attack.\tMechanical\r\nNex\tA siphon will solve this\tKill Nex without letting her heal from her Blood Siphon special attack.\tMechanical\r\nPhantom Muspah\tWalk Straight Pray True\tKill the Phantom Muspah without taking any avoidable damage.\tPerfection\r\nPhantom Muspah\tMore than just a ranged weapon\tKill the Phantom Muspah by only dealing damage to it with a salamander.\tRestriction\r\nPhantom Muspah\tSpace is Tight\tKill the Phantom Muspah whilst it is surrounded by spikes.\tMechanical\r\nPhantom Muspah\tPhantom Muspah Speed-Chaser\tKill the Phantom Muspah in less than 2 minutes without a slayer task.\tSpeed\r\nPhantom Muspah\tEssence Farmer\tKill the Phantom Muspah 10 times in one trip.\tStamina\r\nPhantom Muspah\tPhantom Muspah Master\tKill the Phantom Muspah 50 times.\tKill Count\r\nPhosani\tPhosani's Speedchaser\tDefeat Phosani within 9 minutes.\tSpeed\r\nPhosani\tPhosani's Master\tKill Phosani 5 times.\tKill Count\r\nPhosani\tI Would Simply React\tKill Phosani without allowing your prayer to be disabled.\tMechanical\r\nPhosani\tCrush Hour\tKill Phosani while killing every parasite and husk in one hit.\tMechanical\r\nPhosani\tDreamland Express\tKill Phosani without a sleepwalker reaching her during her desperation phase.\tMechanical\r\nSkotizo\tPrecise Positioning\tKill Skotizo with the final source of damage being a Chinchompa explosion.\tRestriction\r\nThe Nightmare\tPerfect Nightmare\tKill the Nightmare without any player taking damage from the following attacks: Nightmare rifts, an un-cured parasite explosion, Corpse flowers or the Nightmare's Surge. Also, no player can take damage off prayer or have their attacks slowed by the Nightmare spores.\tPerfection\r\nThe Nightmare\tNightmare (5-Scale) Speed-Chaser\tDefeat the Nightmare (5-scale) in less than 4 minutes.\tSpeed\r\nThe Nightmare\tNightmare Master\tKill The Nightmare 50 times.\tKill Count\r\nThe Nightmare\tNightmare (Solo) Speed-Chaser\tDefeat the Nightmare (Solo) in less than 19 minutes.\tSpeed\r\nToB\tPerfect Xarpus\tKill Xarpus without anyone in the team taking any damage from Xarpus' attacks and without letting an exhumed heal Xarpus more than twice.\tPerfection\r\nToB\tTheatre (5-Scale) Speed-Chaser\tComplete the ToB (5-scale) in less than 16 minutes.\tSpeed\r\nToB\tPerfect Verzik\tDefeat Verzik Vitur without anyone in the team taking damage from Verzik Vitur's attacks other than her spider form's correctly prayed against regular magical and ranged attacks.\tPerfection\r\nToB\tTheatre (4-Scale) Speed-Chaser\tComplete the ToB (4-scale) in less than 17 minutes.\tSpeed\r\nToB\tA Timely Snack\tKill Sotetseg after surviving at least 3 ball attacks without sharing the damage and without anyone dying throughout the fight.\tMechanical\r\nToB\tBack in My Day...\tComplete the ToB without any member of the team equipping a Scythe of Vitur.\tRestriction\r\nToB\tPerfect Sotesteg\tKill Sotetseg without anyone in the team stepping on the wrong tile in the maze, without getting hit by the tornado and without taking any damage from Sotetseg's attacks whilst off prayer.\tPerfection\r\nToB\tCan't Drain This\tKill The Maiden of Sugadinti without anyone in the team losing any prayer points.\tRestriction\r\nToB\tCan You Dance?\tKill Xarpus without anyone in the team using a ranged or magic weapon.\tRestriction\r\nToB\tPop It\tKill Verzik without any Nylocas being frozen and without anyone taking damage from the Nylocas.\tMechanical\r\nToB\tTheatre (Trio) Speed-Chaser\tComplete the ToB (Trio) in less than 20 minutes.\tSpeed\r\nToB\tTwo-Down\tKill the Pestilent Bloat before he shuts down for the third time.\tMechanical\r\nToB\tPerfect Maiden\tKill The Maiden of Sugadinti without anyone in the team taking damage from the following sources: Blood Spawn projectiles and Blood Spawn trails. Also, without taking damage off prayer and without letting any of the Nylocas Matomenos heal The Maiden.\tPerfection\r\nToB\tPerfect Bloat\tKill the Pestilent Bloat without anyone in the team taking damage from the following sources: Pestilent flies, Falling body parts or The Pestilent Bloats stomp attack.\tPerfection\r\nToB\tToB Master\tComplete the ToB 75 times.\tKill Count\r\nToB\tPerfect Nylocas\tKill the Nylocas Vasilias without anyone in the team attacking any Nylocas with the wrong attack style, without letting a pillar collapse and without getting hit by any of the Nylocas Vasilias attacks whilst off prayer.\tPerfection\r\nToB: Entry Mode\tToB: SM Speed-Chaser\tComplete the ToB: Entry Mode in less than 17 minutes.\tSpeed\r\nToB: Hard Mode\tHard Mode? Completed It\tComplete the ToB: Hard Mode within the challenge time.\tSpeed\r\nToA\tBetter get movin'\tDefeat Elidinis' Warden in phase three of the Wardens fight with 'Aerial Assault', 'Stay vigilant' and 'Insanity' invocations activated and without dying yourself.\tMechanical\r\nToA\tTomb Raider\tComplete the ToA 50 times.\tKill Count\r\nToA\tChompington\tDefeat Zebak using only melee attacks and without dying yourself.\tMechanical\r\nToA\tTombs Speed Runner\tComplete the ToA (normal) within 18 mins at any group size.\tSpeed\r\nToA\tTomb Looter\tComplete the ToA 25 times.\tKill Count\r\nToA\tPerfect Akkha\tComplete Akkha in a group of two or more, without anyone taking any damage from the following: Akkha's attacks off-prayer, Akkha's special attacks (orbs, memory, detonate), exploding shadow timers, orbs in the enrage phase or attacking Akkha with the wrong style. You must have all Akkha invocations activated.\tPerfection\r\nToA\tPerfect Scabaras\tComplete the Scabaras room in less than a minute without anyone taking any damage from puzzles.\tPerfection\r\nToA\tPerfect Kephri\tDefeat Kephri in a group of two or more, without anyone taking any damage from the following: egg explosions, Kephri's attacks, Exploding Scarabs, Bodyguards, dung attacks. No eggs may hatch throughout the fight.\tPerfection\r\nToA\tPerfect Zebak\tDefeat Zebak without anyone taking any damage from: poison, Zebak's basic attacks off-prayer, blood spawns and waves. You also must not push more than two jugs on the roar attack during the fight (you may destroy stationary ones). You must have all Zebak invocations activated.\tPerfection\r\nToA\tYou are not prepared\tComplete a full ToA raid only using supplies given inside the tomb and without anyone dying.\tRestriction\r\nToA\tPerfect Ba-Ba\tDefeat Ba-Ba in a group of two or more, without anyone taking any damage from the following: Ba-Ba's Attacks off-prayer, Ba-Ba's slam, rolling boulders, rubble attack or falling rocks. No sarcophagi may be opened. You must have all Ba-Ba invocations activated.\tPerfection\r\nToA\tPerfect Wardens\tDefeat The Wardens in a group of two or more, without anyone taking avoidable damage from the following: Warden attacks, obelisk attacks, lightning attacks in phase three, skull attack in phase three, Demi god attacks in phase three. You must have all Wardens invocations activated.\tPerfection\r\nToA: Expert Mode\tBa-Bananza\tDefeat Ba-Ba with all Ba-Ba invocations activated and the path levelled up to at least four, without dying yourself.\tMechanical\r\nToA: Expert Mode\tDoesn't bug me\tDefeat Kephri with all Kephri invocations activated and the path levelled up to at least four, without dying yourself.\tMechanical\r\nToA: Expert Mode\tBut... Damage\tComplete the ToA without anyone in your party wearing or holding any equipment at tier 75 or above.\tRestriction\r\nToA: Expert Mode\tWarden't you believe it\tDefeat the Wardens with all Wardens invocations activated, at expert level and without dying yourself.\tMechanical\r\nToA: Expert Mode\tFancy feet\tComplete phase three of The Wardens in a group of two or more, using only melee attacks and without dying yourself. The 'Insanity' invocation must be activated.\tRestriction\r\nToA: Expert Mode\tSomething of an expert myself\tComplete the ToA raid at level 350 or above without anyone dying.\tMechanical\r\nToA: Expert Mode\tExpert Tomb Looter\tComplete the ToA (Expert mode) 25 times.\tKill Count\r\nToA: Expert Mode\tAll out of medics\tDefeat Kephri without letting her heal above 25% after the first down. The 'Medic' invocation must be activated. You must do this without dying yourself.\tMechanical\r\nToA: Expert Mode\tResourceful Raider\tComplete the ToA with the \"On a diet\" and \"Dehydration\" invocations activated and without anyone dying.\tRestriction\r\nToA: Expert Mode\tRockin' around the croc\tDefeat Zebak with all Zebak invocations activated and the path levelled up to at least four, without dying yourself.\tMechanical\r\nTzHaar Challenges\tThe IV Jad Challenge\tComplete TzHaar-Ket-Rak's fourth challenge.\tKill Count\r\nTzHaar Challenges\tMulti-Style Specialist\tComplete TzHaar-Ket-Rak's third challenge while using a different attack style for each JalTok-Jad.\tMechanical\r\nTzHaar Challenges\tTzHaar-Ket-Rak's Speed-Chaser\tComplete TzHaar-Ket-Rak's third challenge in less than 3 minutes.\tSpeed\r\nTzHaar Challenges\tFacing Jad Head-on IV\tComplete TzHaar-Ket-Rak's fourth challenge with only melee.\tRestriction\r\nTzHaar Challenges\tSupplies? Who Needs 'em?\tComplete TzHaar-Ket-Rak's third challenge without having anything in your inventory.\tPerfection\r\nTzKal-Zuk\tNibblers, Begone!\tKill Tzkal-Zuk without letting a pillar fall before wave 67.\tPerfection\r\nTzTok-Jad\tYou Didn't Say Anything About a Bat\tComplete the Fight Caves without being attacked by a Tz-Kih.\tMechanical\r\nTzTok-Jad\tDenying the Healers\tComplete the Fight caves without letting any of the Yt-MejKot heal.\tMechanical\r\nTzTok-Jad\tFight Caves Master\tComplete the Fight Caves 5 times.\tKill Count\r\nTzTok-Jad\tFight Caves Speed-Chaser\tComplete the Fight Caves in less than 30 minutes.\tSpeed\r\nVorkath\tThe Walk\tHit Vorkath 12 times during the acid special without getting hit by his rapid fire or the acid pools.\tMechanical\r\nVorkath\tExtended Encounter\tKill Vorkath 10 times without leaving his area.\tStamina\r\nVorkath\tDodging the Dragon\tKill Vorkath 5 times without taking any damage from his special attacks and without leaving his area.\tPerfection\r\nVorkath\tVorkath Speed-Chaser\tKill Vorkath in less than 1 minute and 15 seconds.\tSpeed\r\nVorkath\tVorkath Master\tKill Vorkath 100 times.\tKill Count\r\nZulrah\tPerfect Zulrah\tKill Zulrah whilst taking no damage from the following: Snakelings, Venom Clouds, Zulrah's Green or Crimson phase.\tPerfection\r\nZulrah\tZulrah Master\tKill Zulrah 150 times.\tKill Count\r\nZulrah\tZulrah Speed-Chaser\tKill Zulrah in less than 1 minute, without a slayer task.\tSpeed";
        static string GrandmasterList = "Alchemical Hydra\tAlchemical Speed-Runner\tKill the Alchemical Hydra in less than 1 minute 20 seconds.\tSpeed\r\nAlchemical Hydra\tNo Pressure\tKill the Alchemical Hydra using only Dharok's Greataxe as a weapon whilst having no more than 10 Hitpoints throughout the entire fight.\tRestriction\r\nCoX\tCoX (5-Scale) Speed-Runner\tComplete a CoX (5-scale) in less than 12 minutes and 30 seconds.\tSpeed\r\nCoX\tCoX Grandmaster\tComplete the CoX 150 times.\tKill Count\r\nCoX\tCoX (Solo) Speed-Runner\tComplete a CoX (Solo) in less than 17 minutes.\tSpeed\r\nCoX\tCoX (Trio) Speed-Runner\tComplete a CoX (Trio) in less than 14 minutes and 30 seconds.\tSpeed\r\nCoX: Challenge Mode\tCoX: CM (Solo) Speed-Runner\tComplete a CoX: Challenge Mode (Solo) in less than 38 minutes and 30 seconds.\tSpeed\r\nCoX: Challenge Mode\tCoX: CM Grandmaster\tComplete the CoX: Challenge Mode 25 times.\tKill Count\r\nCoX: Challenge Mode\tCoX: CM (Trio) Speed-Runner\tComplete a CoX: Challenge Mode (Trio) in less than 27 minutes.\tSpeed\r\nCoX: Challenge Mode\tCoX: CM (5-Scale) Speed-Runner\tComplete a CoX: Challenge Mode (5-scale) in less than 25 minutes.\tSpeed\r\nCommander Zilyana\tPeach Conjurer\tKill Commander Zilyana 50 times in a private instance times without leaving the room.\tStamina\r\nCommander Zilyana\tAnimal Whisperer\tKill Commander Zilyana in a private instance without taking any damage from the boss or bodyguards.\tPerfection\r\nCorrupted Hunllef\tCorrupted Gauntlet Speed-Runner\tComplete a Corrupted Gauntlet in less than 6 minutes and 30 seconds.\tSpeed\r\nCorrupted Hunllef\tEgniol Diet II\tKill the Corrupted Hunllef without making an egniol potion within the Corrupted Gauntlet.\tRestriction\r\nCorrupted Hunllef\tCorrupted Gauntlet Grandmaster\tComplete the Corrupted Gauntlet 50 times.\tKill Count\r\nCorrupted Hunllef\tWolf Puncher II\tKill the Corrupted Hunllef without making more than one attuned weapon.\tRestriction\r\nCrystalline Hunllef\tGauntlet Speed-Runner\tComplete the Gauntlet in less than 4 minutes.\tSpeed\r\nGeneral Graardor\tOurg Killer\tKill General Graardor 15 times in a private instance without leaving the room.\tStamina\r\nGeneral Graardor\tDefence Matters\tKill General Graardor 2 times consecutively in a private instance without taking any damage from his bodyguards.\tPerfection\r\nGeneral Graardor\tKeep Away\tKill General Graardor in a private instance without taking any damage from the boss or bodyguards.\tPerfection\r\nGrotesque Guardians\tGrotesque Guardians Speed-Runner\tKill the Grotesque Guardians in less than 1:20 minutes.\tSpeed\r\nK'ril Tsutsaroth\tDemon Whisperer\tKill K'ril Tsutsaroth in a private instance without ever being hit by his bodyguards.\tPerfection\r\nK'ril Tsutsaroth\tAsh Collector\tKill K'ril Tsutsaroth 20 times in a private instance without leaving the room.\tStamina\r\nKree'arra\tFeather Hunter\tKill Kree'arra 30 times in a private instance without leaving the room.\tStamina\r\nKree'arra\tThe Worst Ranged Weapon\tKill Kree'arra by only dealing damage to him with a salamander.\tRestriction\r\nNex\tNex Duo\tKill Nex with two or less players at the start of the fight.\tRestriction\r\nNex\tPerfect Nex\tKill Nex whilst completing the requirements for \"There is no escape\", \"Shadows move\", \"A siphon will solve this\", and \"Contain this!\"\tPerfection\r\nNex\tI should see a doctor\tKill Nex whilst a player is coughing.\tRestriction\r\nPhantom Muspah\tPhantom Muspah Manipulator\tKill the Phantom Muspah whilst completing Walk Straight Pray True, Space is Tight & Can't Escape.\tPerfection\r\nPhantom Muspah\tPhantom Muspah Speed-Runner\tKill the Phantom Muspah in less than 1 minute and 30 seconds without a slayer task.\tSpeed\r\nPhosani\tPhosani's Speedrunner\tDefeat Phosani within 7:30 minutes.\tSpeed\r\nPhosani\tPerfect Phosani\tKill Phosani while only taking damage from husks, power blasts and weakened Parasites. Also, without having your attacks slowed by the Nightmare Spores or letting a Sleepwalker reach Phosani.\tPerfection\r\nPhosani\tCan't Wake Up\tKill Phosani 5 times in a row without leaving Phosani's Dream.\tStamina\r\nPhosani\tPhosani's Grandmaster\tKill Phosani 25 times.\tKill Count\r\nThe Nightmare\tTerrible Parent\tKill the Nightmare solo without the Parasites healing the boss for more than 100 health.\tMechanical\r\nThe Nightmare\tNightmare (Solo) Speed-Runner\tDefeat the Nightmare (Solo) in less than 16 minutes.\tSpeed\r\nThe Nightmare\tA Long Trip\tKill the Nightmare without any player losing any prayer points.\tRestriction\r\nThe Nightmare\tNightmare (5-Scale) Speed-Runner\tDefeat the Nightmare (5-scale) in less than 3:30 minutes.\tSpeed\r\nToB\tTheatre (4-Scale) Speed-Runner\tComplete the ToB (4-scale) in less than 15 minutes.\tSpeed\r\nToB\tToB Grandmaster\tComplete the ToB 150 times.\tKill Count\r\nToB\tPerfect Theatre\tComplete the ToB without anyone dying through any means and whilst everyone in the team completes the following Combat Achievement tasks in a single run: \"Perfect Maiden\", \"Perfect Bloat\", \"Perfect Nylocas\", \"Perfect Sotetseg\", \"Perfect Xarpus\" and \"Perfect Verzik\".\tPerfection\r\nToB\tMorytania Only\tComplete the ToB without any member of the team equipping a non-barrows weapon (except Dawnbringer).\tRestriction\r\nToB\tTheatre (Trio) Speed-Runner\tComplete the ToB (Trio) in less than 17 minutes and 30 seconds.\tSpeed\r\nToB\tTheatre (Duo) Speed-Runner\tComplete the ToB (Duo) in less than 26 minutes.\tSpeed\r\nToB\tTheatre (5-Scale) Speed-Runner\tComplete the ToB (5-scale) in less than 14 minutes and 15 seconds.\tSpeed\r\nToB: Hard Mode\tTheatre: HM (5-Scale) Speed-Runner\tComplete the ToB: Hard Mode (5-scale) with an overall time of less than 19 minutes.\tSpeed\r\nToB: Hard Mode\tPack Like a Yak\tComplete the ToB: Hard Mode within the challenge time, with no deaths and without anyone buying anything from a supply chest.\tRestriction\r\nToB: Hard Mode\tTheatre: HM (4-Scale) Speed-Runner\tComplete the ToB: Hard Mode (4-scale) with an overall time of less than 21 minutes.\tSpeed\r\nToB: Hard Mode\tToB: HM Grandmaster\tComplete the ToB: Hard Mode 50 times.\tKill Count\r\nToB: Hard Mode\tHarder Mode I\tDefeat Sotetseg in the ToB: Hard Mode without anyone sharing the ball with anyone, without anyone dying, and without anyone taking damage from any of its other attacks or stepping on the wrong tile in the maze.\tPerfection\r\nToB: Hard Mode\tNylo Sniper\tDefeat Verzik Vitur's in the ToB: Hard Mode without anyone in your team causing a Nylocas to explode by getting too close.\tMechanical\r\nToB: Hard Mode\tTheatre: HM (Trio) Speed-Runner\tComplete the ToB: Hard Mode (Trio) with an overall time of less than 23 minutes.\tSpeed\r\nToB: Hard Mode\tTeam Work Makes the Dream Work\tWhen Verzik Vitur in the ToB: Hard Mode uses her yellow power blast attack while the tornadoes are active, have everyone get through the attack without taking damage. This cannot be completed with one player alive\tMechanical\r\nToB: Hard Mode\tHarder Mode III\tDefeat Verzik Vitur in the ToB: Hard Mode without anyone attacking her with a melee weapon during her third phase.\tRestriction\r\nToB: Hard Mode\tStop Right There!\tDefeat the Maiden of Sugadinti in the ToB: Hard Mode without letting blood spawns create more than 15 blood trails.\tMechanical\r\nToB: Hard Mode\tPersonal Space\tDefeat the Pestilent Bloat in the ToB: Hard Mode with a least 3 people in the room, without anyone in your team standing on top of each other.\tMechanical\r\nToB: Hard Mode\tRoyal Affairs\tIn the ToB: Hard Mode, complete the Nylocas room without ever letting the Nylocas Prinkipas change styles.\tMechanical\r\nToB: Hard Mode\tHarder Mode II\tDefeat Xarpus in the ToB: Hard Mode after letting the exhumeds heal him to full health and without anyone in the team taking any damage.\tPerfection\r\nToA: Expert Mode\tAll Praise Zebak\tDefeat Zebak without losing a single prayer point. You must also meet the conditions of the 'Rockin' Around The Croc' achievement.\tMechanical\r\nToA: Expert Mode\tAmascut's Remnant\tComplete the ToA at raid level 500 or above without anyone dying.\tMechanical\r\nToA: Expert Mode\tExpert Tomb Raider\tComplete the ToA (Expert mode) 50 times.\tKill Count\r\nToA: Expert Mode\tPerfection of Apmeken\tComplete 'Perfect Apmeken' and 'Perfect Ba-Ba' in a single run of the ToA.\tPerfection\r\nToA: Expert Mode\tPerfection of Het\tComplete 'Perfect Het' and 'Perfect Akkha' in a single run of the ToA.\tPerfection\r\nToA: Expert Mode\tTombs Speed Runner III\tComplete the ToA (expert) within 18 mins in a group of 8.\tSpeed\r\nToA: Expert Mode\tPerfection of Scabaras\tComplete 'Perfect Scabaras' and 'Perfect Kephri' in a single run of ToA.\tPerfection\r\nToA: Expert Mode\tInsanity\tComplete 'Perfect Wardens' at expert or above.\tPerfection\r\nToA: Expert Mode\tTombs Speed Runner II\tComplete the ToA (expert) within 20 mins at any group size.\tSpeed\r\nToA: Expert Mode\tPerfection of Crondis\tComplete 'Perfect Crondis' and 'Perfect Zebak' in a single run of the ToA.\tPerfection\r\nToA: Expert Mode\tAkkhan't Do it\tDefeat Akkha with all Akkha invocations activated and the path levelled up to at least four, without dying yourself.\tMechanical\r\nToA: Expert Mode\tMaybe I'm the boss.\tComplete a ToA raid with every single boss invocation activated and without anyone dying.\tMechanical\r\nTzHaar Challenges\tThe VI Jad Challenge\tComplete TzHaar-Ket-Rak's sixth challenge.\tKill Count\r\nTzHaar Challenges\tTzHaar-Ket-Rak's Speed-Runner\tComplete TzHaar-Ket-Rak's fifth challenge in less than 5 minutes.\tSpeed\r\nTzHaar Challenges\tIt Wasn't a Fluke\tComplete TzHaar-Ket-Rak's fifth and sixth challenges back to back without failing.\tPerfection\r\nTzKal-Zuk\tWasn't Even Close\tKill Tzkal-Zuk without letting your hitpoints fall below 50 during any wave in the Inferno.\tRestriction\r\nTzKal-Zuk\tJad? What Are You Doing Here?\tKill Tzkal-Zuk without killing the JalTok-Jad which spawns during wave 69.\tRestriction\r\nTzKal-Zuk\tBudget Setup\tKill Tzkal-Zuk without equipping a Twisted Bow within the Inferno.\tRestriction\r\nTzKal-Zuk\tThe Floor Is Lava\tKill Tzkal-Zuk without letting Jal-ImKot dig during any wave in the Inferno.\tMechanical\r\nTzKal-Zuk\tNibbler Chaser\tKill Tzkal-Zuk without using any magic spells during any wave in the Inferno.\tRestriction\r\nTzKal-Zuk\tInferno Grandmaster\tComplete the Inferno 5 times.\tKill Count\r\nTzKal-Zuk\tFacing Jad Head-on II\tKill Tzkal-Zuk without equipping any range or mage weapons before wave 69.\tRestriction\r\nTzKal-Zuk\tPlaying with Jads\tComplete wave 68 of the Inferno within 30 seconds of the first JalTok-Jad dying.\tMechanical\r\nTzKal-Zuk\tInferno Speed-Runner\tComplete the Inferno in less than 65 minutes.\tSpeed\r\nTzKal-Zuk\tNo Luck Required\tKill Tzkal-Zuk without being attacked by TzKal-Zuk and without taking damage from a JalTok-Jad.\tPerfection\r\nTzTok-Jad\tNo Time for a Drink\tComplete the Fight Caves without losing any prayer points.\tRestriction\r\nTzTok-Jad\tFight Caves Speed-Runner\tComplete the Fight Caves in less than 26 minutes and 30 seconds.\tSpeed\r\nTzTok-Jad\tDenying the Healers II\tComplete the Fight Caves without TzTok-Jad being healed by a Yt-HurKot.\tMechanical\r\nVorkath\tThe Fremennik Way\tKill Vorkath with only your fists.\tRestriction\r\nVorkath\tVorkath Speed-Runner\tKill Vorkath in less than 54 seconds.\tSpeed\r\nVorkath\tFaithless Encounter\tKill Vorkath without losing any prayer points.\tRestriction\r\nZulrah\tZulrah Speed-Runner\tKill Zulrah in less than 54 seconds, without a slayer task.\tSpeed";
        private ListViewColumnSorter lvwColumnSorter;
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string filepath = @"savedata.txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    for (int i = 0; i < 485; ++i) //485 = Total number of tasks
                    {
                        sw.Write("0");
                    }
                    sw.Close();
                }
            }

            string[] lists = { EasyList, MediumList, HardList, EliteList, MasterList, GrandmasterList };
            string[] difficultyLevels = { "Easy", "Medium", "Hard", "Elite", "Master", "Supreme" };

            Dictionary<string, string[]> difficultyMap = new Dictionary<string, string[]>();
            for (int i = 0; i < difficultyLevels.Length; i++)
            {
                difficultyMap[difficultyLevels[i]] = lists[i].Split('\n');
            }

            string text = File.ReadAllText(filepath);

            foreach (KeyValuePair<string, string[]> difficulty in difficultyMap)
            {
                foreach (string line in difficulty.Value)
                {
                    string[] temp = line.Split('\t');
                    Task task = new Task(difficulty.Key, temp[0], temp[1], temp[2], temp[3], text[TaskList.Count] + "");
                    TaskList.Add(task);
                }
            }

            ImageList iList = new ImageList();
            iList.ImageSize = new Size(10, 5);
            listView2.LargeImageList = iList;

            GenerateTable();
        }

        public void GenerateTable()
        {
            listView1.Items.Clear();

            var items = TaskList.Select((task, index) =>
            {
                ListViewItem lvi = new ListViewItem(task.GetTaskInfo());
                lvi.Tag = index;
                return lvi;
            }).ToArray();

            listView1.Items.AddRange(items);

            UpdateTable();
        }

        public void UpdateTable()
        {
            Dictionary<string, (int done, int planned, int total)> taskTiers = new Dictionary<string, (int done, int planned, int total)>()
            {
                { "Easy", (0, 0, 0) },
                { "Medium", (0, 0, 0) },
                { "Hard", (0, 0, 0) },
                { "Elite", (0, 0, 0) },
                { "Master", (0, 0, 0) },
                { "Supreme", (0, 0, 0) }
            };

            foreach (Task t in TaskList)
            {
                if (t.GetStatus() == "2")
                {
                    var (done, planned, total) = taskTiers[t.GetTier()];
                    taskTiers[t.GetTier()] = (done + 1, planned, total + 1);
                }
                else if (t.GetStatus() == "1")
                {
                    var (done, planned, total) = taskTiers[t.GetTier()];
                    taskTiers[t.GetTier()] = (done, planned + 1, total + 1);
                }
                else
                {
                    var (done, planned, total) = taskTiers[t.GetTier()];
                    taskTiers[t.GetTier()] = (done, planned, total + 1);
                }
            }

            for (int i = 0; i < listView2.Items.Count; ++i)
            {
                var tier = taskTiers[taskTiers.Keys.ElementAt(i)];
                listView2.Items[i].Text = $"{taskTiers.Keys.ElementAt(i)}\n{tier.done} / {tier.total}";
                listView2.Items[i].ForeColor = tier.done == tier.total ? Color.Green : (tier.done + tier.planned) == tier.total ? Color.Yellow : Color.Black;
            }

            int ptsPlanned = TaskList.Where(task => task.GetStatus() == "1").Sum(task => Int32.Parse(task.GetPointWorth()));
            int ptsDone = TaskList.Where(task => task.GetStatus() == "2").Sum(task => Int32.Parse(task.GetPointWorth()));


            int[] ranges = { 33, 115, 304, 820, 1465, 2005 };
            int ptsNeeded = ranges.Last() - ptsDone - ptsPlanned;
            int rangeIndex = ranges.TakeWhile(range => range <= ptsDone).Count() - 1;
            if (rangeIndex >= 0 && rangeIndex < ranges.Length - 1)
            {
                ptsNeeded = ranges[rangeIndex + 1] - ptsDone - ptsPlanned;
            }


            foreach (ListViewItem item in listView1.Items)
            {
                int index = int.Parse(item.Tag.ToString());
                string status = TaskList[index].GetStatus();
                item.ForeColor = status switch
                {
                    "0" => Color.Red,
                    "1" => Color.Purple,
                    "2" => Color.Green,
                    _ => Color.Black
                };
            }

            label1.Text = "Completed Points: " + ptsDone.ToString();
            label2.Text = "Points In Progress: " + ptsPlanned.ToString();
            label3.Text = "Points Needed: " + ptsNeeded.ToString();

            for (int i = listView1.Items.Count - 1; i >= 0; --i)
            {
                int tagIndex = Int32.Parse(listView1.Items[i].Tag.ToString());
                if (TaskList[tagIndex].GetStatus() == "2" && cbHideDone.Checked)
                {
                    listView1.Items.RemoveAt(i);
                }
                if (TaskList[tagIndex].GetStatus() == "0" && cbHideIncom.Checked)
                {
                    listView1.Items.RemoveAt(i);
                }
            }

            progressBar1.Value = TaskList.Where(task => task.GetStatus() == "2").Count();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string filepath = @"savedata.txt";
            if (File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    for (int i = 0; i < TaskList.Count; ++i)
                    {
                        sw.Write(TaskList[i].GetStatus());
                    }
                    sw.Close();
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            int tagIndex = Int32.Parse(item.Tag.ToString());
            if (radioButton1.Checked)
            {
                TaskList[tagIndex].SetStatus("2");
                item.ForeColor = Color.Green;
            }
            else if (radioButton2.Checked)
            {
                TaskList[tagIndex].SetStatus("1");
                item.ForeColor = Color.Yellow;
            }
            else
            {
                TaskList[tagIndex].SetStatus("0");
                item.ForeColor = Color.Red;
            }

            UpdateTable();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }

        private void cbHideDone_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbHideDone.Checked)
            {
                listView1.Items.Clear();
                GenerateTable();
            }

            UpdateTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.ShowDialog();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.listView1.Sort();
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "aint work yet";
        }

        private void cbHideIncom_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbHideIncom.Checked)
            {
                listView1.Items.Clear();
                GenerateTable();
            }

            UpdateTable();
        }
    }

    public class Task
    {
        string tier, monster, name, description, type, status;
        // 2 = done, 1 = pending, 0 = incomplete (status)

        public Task(string tier, string monster, string name, string description, string type, string status)
        {
            this.tier = tier;
            this.monster = monster;
            this.name = name;
            this.description = description;
            this.type = type;
            this.status = status;
        }

        public string[] GetTaskInfo()
        {
            return new string[] { tier, monster, name, description, type };
        }

        public string GetStatus()
        {
            return status;
        }
        
        public string GetTier()
        {
            return tier;
        }

        public string GetPointWorth()
        {
            switch (tier)
            {
                case "Easy": return "1";
                case "Medium": return "2";
                case "Hard": return "3";
                case "Elite": return "4";
                case "Master": return "5";
                case "Supreme": return "6";
            }
            return "-5000";
        }

        public void SetStatus(string a)
        {
            this.status = a;
        }
    }

    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}