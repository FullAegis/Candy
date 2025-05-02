# Candy Store Inventory Management API
## Laboratoire: Développement d'un système de gestion d'inventaire pour une boutique en ligne avec API REST

## Objectif

Le but de ce laboratoire est de concevoir un système de gestion d'inventaire pour une boutique en ligne. Ce système doit permettre de gérer les produits, les commandes et les utilisateurs de la boutique.

## Technologies requises

*   ASP.NET Web API pour la création de l'API REST
*   ADO.NET pour la manipulation des données dans la base de données
*   LINQ pour les requêtes sur les collections et les entités
*   JWT pour l'authentification et l'autorisation des utilisateurs

## Description du système

Le système doit permettre aux administrateurs de la boutique d'ajouter de nouveaux produits, de mettre à jour les informations des produits existants, de gérer les commandes passées par les utilisateurs et de suivre l'état des stocks. Les produits seront catégoriser (ex : Frais, Fruit & légume, Électronique, Jouets, ...) Et donc filtrer par catégorie à la demande.

## Fonctionnalités attendues

### 1. Gestion des produits :

*   Endpoint pour ajouter un nouveau produit avec ses détails (nom, description, prix, quantité en stock, etc.).
*   Endpoint pour récupérer la liste de tous les produits disponibles.
*   Endpoint pour récupérer la fiche produit complète (catégorie, prix HTVA + TVAC, ...).
*   Endpoint pour mettre à jour les informations d'un produit existant.
*   Endpoint pour supprimer un produit du catalogue.

### 2. Gestion des commandes :

*   Endpoint pour passer une nouvelle commande avec les détails du produit et de l'utilisateur.
*   Endpoint pour récupérer la liste des commandes passées.
*   Endpoint pour marquer une commande comme traitée ou annulée.

### 3. Gestion des utilisateurs :

*   Endpoint pour l'inscription des nouveaux utilisateurs.
*   Endpoint pour la connexion des utilisateurs, générant et retournant un token JWT valide en cas de succès.
*   Endpoint pour récupérer les informations de l'utilisateur connecté.
*   Endpoint pour mettre à jour le profil utilisateur.
*   Endpoint fournissant l'historique de commande d'un utilisateur.

## Tâches à effectuer

1.  Mise en place du projet ASP.NET Web API.
2.  Configuration de la base de données :
    *   Créer une base de données pour stocker les informations des produits, des commandes et des utilisateurs.
    *   Concevoir des tables pour chaque entité avec les champs appropriés.
3.  Implémentation des endpoints de l'API pour les fonctionnalités décrites ci-dessus.
4.  Utilisation d'ADO.NET pour la manipulation des données dans la base de données.
5.  Utilisation de LINQ pour effectuer des opérations de requêtes et de filtrage sur les données.
6.  Implémentation de l'authentification et de l'autorisation avec JWT pour sécuriser l'accès aux fonctionnalités administratives.

## Livraisons attendues

*   Code source du projet ASP.NET Web API.
*   Documentation décrivant les endpoints de l'API, les méthodes implémentées, ainsi que les instructions pour tester l'API.
*   Rapport détaillant les différentes étapes du développement, les problèmes rencontrés et les solutions adoptées.

## Remarque

Il est recommandé d'utiliser des bonnes pratiques de développement telles que la validation des données en entrée, la gestion des erreurs, la sécurité des données, etc.