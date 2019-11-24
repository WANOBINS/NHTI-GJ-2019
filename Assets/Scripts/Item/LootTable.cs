using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LootTable : MonoBehaviour
{
    public bool alwaysDropAll;
    //DropLimitOverride allows for items with alwaysDrop set to true to drop even if the limit has been reached for the drop limit.
    public bool DropLimitOverride;
    public int dropLimit;
    public LootSettings[] loot;

    public List<LootSettings> LootDrop()
    {
        int roll = 0;
        List<LootSettings> droppedItems = new List<LootSettings>(); 

        foreach (var item in loot)
        {
            roll = Random.RandomRange(1, 100);
            if(!item.alwaysDrop)
            {
                if (roll <= item.dropRate)
                {
                    Debug.Log("Congrats Loot acquired! You rolled: " + roll);
                    droppedItems.Add(item);
                } else {
                    Debug.Log("Luck hasn't been with you! You rolled: " + roll);
                }
            } else {
                Debug.Log("Congrats Loot acquired! No roll required!");
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }

    public List<Loot> LootReceived()
    {
        List<LootSettings> lootInfo = LootDrop();
        List<Loot> loot = new List<Loot>();
        

        if (!alwaysDropAll)
        {
            lootInfo = lootInfo.OrderBy(o => o.dropRate).ToList();
            if (!DropLimitOverride)
            {
                if (lootInfo.Count >= dropLimit)
                {
                    for (int i = 0; i < dropLimit; i++)
                    {
                        Loot drop = new Loot();
                        drop.item = lootInfo[i].item;
                        if (lootInfo[i].randomDropAmt)
                        {
                            drop.Amount = Random.Range(1, lootInfo[i].maxDropAmt+1);
                        }
                        else
                        {
                            drop.Amount = lootInfo[i].dropAmt;
                        }
                        loot.Add(drop);
                    }
                } else {
                    foreach (var item in lootInfo)
                    {
                        Loot drop = new Loot();
                        drop.item = item.item;
                        if (item.randomDropAmt)
                        {
                            drop.Amount = Random.Range(1, item.maxDropAmt + 1);
                        }
                        else
                        {
                            drop.Amount = item.dropAmt;
                        }
                        loot.Add(drop);
                    }
                }
            } else {
                if (lootInfo.Count > dropLimit)
                {
                    List<Loot> alwaysLoot = new List<Loot>();
                    for (int i = lootInfo.Count-1; i >= 0; i--)
                    {
                        if (lootInfo[i].alwaysDrop)
                        {
                            Loot drop = new Loot();
                            drop.item = lootInfo[i].item;
                            if (lootInfo[i].randomDropAmt)
                            {
                                drop.Amount = Random.Range(1, lootInfo[i].maxDropAmt + 1);
                            }
                            else
                            {
                                drop.Amount = lootInfo[i].dropAmt;
                            }
                            alwaysLoot.Add(drop);
                            lootInfo.RemoveAt(i);
                        }
                    }
                    if (lootInfo.Count >= dropLimit)
                    {
                        for (int i = 0; i < dropLimit; i++)
                        {
                            Loot drop = new Loot();
                            drop.item = lootInfo[i].item;
                            if (lootInfo[i].randomDropAmt)
                            {
                                drop.Amount = Random.Range(1, lootInfo[i].maxDropAmt + 1);
                            }
                            else
                            {
                                drop.Amount = lootInfo[i].dropAmt;
                            }
                            loot.Add(drop);
                        }
                    } else {
                        if(lootInfo.Count > 0)
                        {
                            foreach (var item in lootInfo)
                            {
                                Loot drop = new Loot();
                                drop.item = item.item;
                                if (item.randomDropAmt)
                                {
                                    drop.Amount = Random.Range(1, item.maxDropAmt + 1);
                                }
                                else
                                {
                                    drop.Amount = item.dropAmt;
                                }
                                loot.Add(drop);
                            }
                        }
                    }
                    foreach (var item in alwaysLoot)
                    {
                        Loot drop = new Loot();
                        drop.item = item.item;
                        drop.Amount = item.Amount;
                        loot.Add(drop);
                    }
                } else {
                    foreach (var item in lootInfo)
                    {
                        Loot drop = new Loot();
                        drop.item = item.item;
                        if (item.randomDropAmt)
                        {
                            drop.Amount = Random.Range(1, item.maxDropAmt + 1);
                        }
                        else
                        {
                            drop.Amount = item.dropAmt;
                        }
                        loot.Add(drop);
                    }
                }
            }
        } else {
            foreach (var item in lootInfo) {
                Loot drop = new Loot();
                drop.item = item.item;
                if (item.randomDropAmt)
                {
                    drop.Amount = Random.Range(1, item.maxDropAmt + 1);
                }
                else
                {
                    drop.Amount = item.dropAmt;
                }
                loot.Add(drop);
            }
        }
        
        return loot;
    }

}

[System.Serializable]
public class LootSettings
{
    public Item item;
    public bool alwaysDrop;
    public bool randomDropAmt;
    public float dropRate;
    public int dropAmt;
    public int maxDropAmt;
}

[System.Serializable]
public class Loot
{
    public Item item;
    public int Amount;
}