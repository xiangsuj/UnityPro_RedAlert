using System;
using System.Collections.Generic;
using System.Text;
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys=new List<ICharacter>();
    private List<ICharacter> mSoldiers=new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

   

    public override void Update()
    {
       UpdateEnemy();
       UpdateSoldier();
       RemoveCharacterIsKilled(mEnemys);
        RemoveCharacterIsKilled(mSoldiers);
    }
    private void UpdateEnemy()
    {
        foreach (IEnemy enemy in mEnemys)
        {
            enemy.Update();
            enemy.UpdateFSMAI(mSoldiers);
        }
    }
    private void UpdateSoldier()
    {
        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.Update();
            soldier.UpdateFSMAI(mEnemys);
        }
    }
    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter>canDestroys=new List<ICharacter>();
        foreach (ICharacter character in characters)
        {
            if (character.canDestroy)
            {
                canDestroys.Add(character);
            }
        }
        foreach (ICharacter character in canDestroys)
        {
            character.Release();
            characters.Remove(character);
        }
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (ICharacter character in mEnemys)
        {
            character.RunVisitor(visitor);
        }
        foreach (ICharacter character in mSoldiers)
        {
            character.RunVisitor(visitor);
        }
    }
}