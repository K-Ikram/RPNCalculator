- Les améliorations à apporter au projet:
  
  - Ajout d'une couche de repository pour séparer la logique métier (le calcul des opérations) de la manipulation des piles et opérations (exemple get stack by id dans StackRepository).
  - Ajout d'une classe "Operation" contenant un id, la valeur de l'opération (+,-,*,/) et une référence vers leurs piles.
  - Suppression en casscade de la pile et ses opérations.
  - Ajout de plus de tests unitaire et d'intégration.
  - Ajout des exceptions personnalisées.
  - Sécuriser l'API avec le protocole HTTPS.