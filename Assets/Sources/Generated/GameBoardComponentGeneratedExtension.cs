//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public GameBoardComponent gameBoard { get { return (GameBoardComponent)GetComponent(ComponentIds.GameBoard); } }

        public bool hasGameBoard { get { return HasComponent(ComponentIds.GameBoard); } }

        public Entity AddGameBoard(int newColumns, int newRows, int newDepths) {
            var component = CreateComponent<GameBoardComponent>(ComponentIds.GameBoard);
            component.columns = newColumns;
            component.rows = newRows;
            component.depths = newDepths;
            return AddComponent(ComponentIds.GameBoard, component);
        }

        public Entity ReplaceGameBoard(int newColumns, int newRows, int newDepths) {
            var component = CreateComponent<GameBoardComponent>(ComponentIds.GameBoard);
            component.columns = newColumns;
            component.rows = newRows;
            component.depths = newDepths;
            ReplaceComponent(ComponentIds.GameBoard, component);
            return this;
        }

        public Entity RemoveGameBoard() {
            return RemoveComponent(ComponentIds.GameBoard);
        }
    }

    public partial class Pool {
        public Entity gameBoardEntity { get { return GetGroup(Matcher.GameBoard).GetSingleEntity(); } }

        public GameBoardComponent gameBoard { get { return gameBoardEntity.gameBoard; } }

        public bool hasGameBoard { get { return gameBoardEntity != null; } }

        public Entity SetGameBoard(int newColumns, int newRows, int newDepths) {
            if (hasGameBoard) {
                throw new EntitasException("Could not set gameBoard!\n" + this + " already has an entity with GameBoardComponent!",
                    "You should check if the pool already has a gameBoardEntity before setting it or use pool.ReplaceGameBoard().");
            }
            var entity = CreateEntity();
            entity.AddGameBoard(newColumns, newRows, newDepths);
            return entity;
        }

        public Entity ReplaceGameBoard(int newColumns, int newRows, int newDepths) {
            var entity = gameBoardEntity;
            if (entity == null) {
                entity = SetGameBoard(newColumns, newRows, newDepths);
            } else {
                entity.ReplaceGameBoard(newColumns, newRows, newDepths);
            }

            return entity;
        }

        public void RemoveGameBoard() {
            DestroyEntity(gameBoardEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGameBoard;

        public static IMatcher GameBoard {
            get {
                if (_matcherGameBoard == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GameBoard);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGameBoard = matcher;
                }

                return _matcherGameBoard;
            }
        }
    }
}
