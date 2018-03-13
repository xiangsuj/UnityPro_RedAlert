using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//游戏状态的 外观模式   各个系统的中介者模式
public class GameFacade
{
    private static GameFacade _instance=new GameFacade();
    private GameFacade() { }
    public static GameFacade Instance { get { return _instance; } }
    private bool mIsGameOver = false;

    public bool isGameOver{ get { return mIsGameOver; } }

    private ArchievementSystem mArchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private StageSystem mStageSystem;
    private GameEventSystem mGameEventSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init()
    {
        mArchievementSystem=new ArchievementSystem();
        mCharacterSystem=new CharacterSystem();
        mCampSystem=new CampSystem();
        mEnergySystem=new EnergySystem();
        mStageSystem=new StageSystem();
        mGameEventSystem=new GameEventSystem();

        mCampInfoUI=new CampInfoUI();
        mGamePauseUI=new GamePauseUI();
        mGameStateInfoUI=new GameStateInfoUI();
        mSoldierInfoUI=new SoldierInfoUI();

        mArchievementSystem.Init();
        mCharacterSystem.Init();
        mCampSystem.Init();
        mEnergySystem.Init();
        mStageSystem.Init();
        mGameEventSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();
    }

    public void Update()
    {
        mArchievementSystem.Update();
        mCharacterSystem.Update();
        mCampSystem.Update();
        mEnergySystem.Update();
        mStageSystem.Update();
        mGameEventSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        CreateMemento();

        mArchievementSystem.Release();
        mCharacterSystem.Release();
        mCampSystem.Release();
        mEnergySystem.Release();
        mStageSystem.Release();
        mGameEventSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();


    }

    public Vector3 GetEnemyTargetPosition()
    {
        return mStageSystem.TargetPosition;
    }
    public void ShowCampInfo(ICamp camp)
    {
        mCampInfoUI.ShowCampInfo(camp);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }
    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mCharacterSystem.RemoveEnemy(enemy);
    }
    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }
    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }
    public void ShowMessage(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }
    public void UpdateEnergySlider(int currentEnergy, int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(currentEnergy,maxEnergy);
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType,observer);
    }
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType,observer);
    }
    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSystem.NotifySubject(eventType);
    }
    private void LoadMemento()
    {
        AchievementMemento memento=new AchievementMemento();
        memento.LoadData();
        mArchievementSystem.SetMemento(memento);
    }
    private void CreateMemento()
    {
        AchievementMemento memento = mArchievementSystem.CreateMemento();
        memento.SaveData();

    }
    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }
}