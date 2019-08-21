using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<CakeLayer> cakeLayers = new List<CakeLayer>();

    [SerializeField] private TowerOfHanoi towerOfHanoi;

    [SerializeField] private bool isGoal;

    public Renderer plateRenderer;

    //Adiciona um filho ao objeto da Torre e adiciona o filho à lista de camadas de bolo
    public void AddChild(CakeLayer _newCakeLayer)
    {
        if (cakeLayers.Count == 0 || _newCakeLayer.cakeSize.x < cakeLayers[cakeLayers.Count - 1].cakeSize.x)
        {
            _newCakeLayer.currentTower.RemoveChild();
            _newCakeLayer.currentTower = this;
            cakeLayers.Add(_newCakeLayer);

            towerOfHanoi.MakeMove();

            if (cakeLayers.Count > 1)
            {
                cakeLayers[cakeLayers.Count - 1].transform.position = new Vector3(transform.position.x, (cakeLayers[cakeLayers.Count - 1].cakeSize.y / 2) + (cakeLayers[cakeLayers.Count - 2].cakeSize.y / 2 + cakeLayers[cakeLayers.Count - 2].transform.position.y), transform.position.z);

                cakeLayers[cakeLayers.Count - 2].cakeCollider.enabled = false;
            }
            else
            {
                cakeLayers[0].transform.position = new Vector3(transform.position.x, cakeLayers[0].cakeSize.y / 2 + 0.15f, transform.position.z);
            }
            cakeLayers[cakeLayers.Count - 1].currentPosition = cakeLayers[cakeLayers.Count - 1].transform.position;
            if(isGoal)
            {
                if(cakeLayers.Count == towerOfHanoi.GetCurrentTowerPieces())
                {
                    if(towerOfHanoi.currentMoves == towerOfHanoi.minMoves)
                    {
                        //Final bom
                        towerOfHanoi.endText.text = string.Format("Você conseguiu o melhor \nresultado possível! \nTotal de movimentos: <color #d18385>{0}</color>", towerOfHanoi.currentMoves.ToString());
                        towerOfHanoi.ending.SetActive(true);
                        AudioPlayer.instance.PlayBGM(towerOfHanoi.endingSong);
                    }
                    else
                    {
                        //Final meh
                        towerOfHanoi.endText.text = string.Format("Você conseguiu terminar a torre! \n Mas esse não é o melhor resultado possível. \nTotal de movimentos: <color #d18385>{0}</color>", towerOfHanoi.currentMoves.ToString());
                        towerOfHanoi.ending.SetActive(true);
                        AudioPlayer.instance.PlayBGM(towerOfHanoi.endingSong);
                    }
                }
            }
        }
        else
        {
            _newCakeLayer.transform.position = _newCakeLayer.currentPosition;
        }
    }

    public void RemoveChild()
    {
        cakeLayers.RemoveAt(cakeLayers.Count - 1);
        if (cakeLayers.Count > 0)
        {
            cakeLayers[cakeLayers.Count - 1].cakeCollider.enabled = true;
        }
    }

    public void PopulateList(CakeLayer _newCakeLayer)
    {
        _newCakeLayer.currentTower = this;
        cakeLayers.Add(_newCakeLayer);        
        
        if (cakeLayers.Count > 1)
        {
            cakeLayers[cakeLayers.Count - 1].transform.position = new Vector3(transform.position.x, (cakeLayers[cakeLayers.Count - 1].cakeSize.y / 2) + (cakeLayers[cakeLayers.Count - 2].cakeSize.y / 2 + cakeLayers[cakeLayers.Count - 2].transform.position.y), transform.position.z);            
            cakeLayers[cakeLayers.Count - 1].currentPosition = cakeLayers[cakeLayers.Count - 1].transform.position;

            cakeLayers[cakeLayers.Count - 2].cakeCollider.enabled = false;
        }
        else
        {
            cakeLayers[0].transform.position = new Vector3(transform.position.x, cakeLayers[0].cakeSize.y / 2 + 0.15f, transform.position.z);
        }
        cakeLayers[cakeLayers.Count - 1].currentPosition = cakeLayers[cakeLayers.Count - 1].transform.position;
    }

    public void ResetList()
    {
        cakeLayers.Clear();
    }
}