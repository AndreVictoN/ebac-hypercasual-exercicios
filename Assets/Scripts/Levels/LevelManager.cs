using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;
    //public List<GameObject> levels;

    [Header("Pieces")]
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;
    public float timeBetweenPieces = .3f;

    //Privates
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup _currSetup;

    //private GameObject _currentLevel;
    private int _index = 0;

    void Awake()
    {
        //SpawnLevels();
        CreateLevelPieces();
    }

    /*public void SpawnLevels()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);

            _index++;

            if(_index >= levels.Count)
            {
                _index = 0;
            }
        }

        _currentLevel = Instantiate(levels[_index], container);

        _currentLevel.transform.localPosition = Vector3.zero;
    }*/

    #region Pieces
    private void CreateLevelPieces()
    {
        CleanSpawnedPieces();

        if(_currSetup != null)
        {
            _index++;

            if(_index >= levelPieceBasedSetups.Count)
            {
                _index = 0;
            }
        }

        _currSetup = levelPieceBasedSetups[_index];

        for(int i = 0; i < _currSetup.numberStartPieces; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }

        for(int i = 0; i < _currSetup.numberPieces; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }

        for(int i = 0; i < _currSetup.numberEndPieces; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currSetup.artType);
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            CreateLevelPieces();
        }
    }
}
