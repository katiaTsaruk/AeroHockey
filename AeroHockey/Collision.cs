namespace AeroHockey
{
    public class Collision
    {
        ///TODO: проверять на колизию и задавать направление
        
        
        public bool CheckForCollision(float deltaX,float deltaY)
        {
            float x=ball.circleShape.Position.X + deltaX;
            float y=ball.circleShape.Position.Y + deltaY;
            if (x >= windowWidth -2*ball.radius-5 && x <= 2*ball.radius-15 && y <= 2*ball.radius-15  && y >= windowHeight - 2*ball.radius-5 )
                return false;
            else return true;
        }
    }
}