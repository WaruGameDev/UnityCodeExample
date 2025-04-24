using System.Collections.Generic;
using UnityEngine;

// Enum que define los posibles estados de una misión
public enum QuestStatus
{
    unnassigned, // No asignada
    assigned,    // Asignada pero no terminada
    finished,    // Terminada pero no completada oficialmente
    completed    // Completada completamente
}

// Clase que representa una misión individual
[System.Serializable]
public class Quest
{
    public string questName;       // Nombre de la misión
    public QuestStatus status;     // Estado actual de la misión
}

// Gestor de misiones (singleton)
public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;   // Instancia global (singleton)
    public List<Quest> quests;             // Lista de misiones disponibles

    // Se ejecuta cuando se instancia el objeto (Unity lifecycle)
    private void Awake()
    {
        instance = this; // Se asigna la instancia actual para acceso global
    }

    // Devuelve el estado de una misión por su nombre
    public QuestStatus GetQuestStatus(string questName)
    {
        foreach (var q in quests)
        {
            if (q.questName == questName)
            {
                return q.status; // Retorna el estado si la misión existe
            }
        }

        return QuestStatus.unnassigned; // Si no se encuentra, retorna 'unnassigned'
    }

    // Cambia el estado de una misión existente
    public void SetupQuest(string questName, QuestStatus questStatus)
    {
        foreach (var q in quests)
        {
            if (q.questName == questName)
            {
                q.status = questStatus; // Actualiza el estado
            }
        }
    }

    // Verifica si una misión existe por su nombre
    public bool CheckIfQuestExists(string questName)
    {
        foreach (var q in quests)
        {
            if (q.questName == questName)
            {
                return true; // La misión existe
            }
        }

        return false; // No se encontró la misión
    }

    // Agrega una nueva misión a la lista
    public void AddQuest(string questName, QuestStatus questStatus)
    {
        quests.Add(new Quest { questName = questName, status = questStatus });
    }
}
