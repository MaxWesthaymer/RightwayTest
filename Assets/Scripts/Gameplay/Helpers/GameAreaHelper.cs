using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        public static float RightBound => _rightBound;
        public static float LeftBound => _leftBound;
        
        private static Camera _camera;
        private static float _rightBound;
        private static float _leftBound;
        private static float _bottomBound;
        private static float _topBound;

        static GameAreaHelper()
        {
            SetCamera();
            CalculateCameraBounds();
        }

        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            if (_camera == null)
            {
                SetCamera();
                CalculateCameraBounds();
            }

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < RightBound)
                && (objectPos.x + objectBounds.extents.x > LeftBound)
                && (objectPos.y - objectBounds.extents.y < _topBound)
                && (objectPos.y + objectBounds.extents.y > _bottomBound);

        }

        private static void CalculateCameraBounds()
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            _topBound = camPos.y + camHalfHeight;
            _bottomBound = camPos.y - camHalfHeight;
            _leftBound = camPos.x - camHalfWidth;
            _rightBound = camPos.x + camHalfWidth;
        }

        private static void SetCamera() => _camera = Camera.main;
    }
}
