# Criação de uma definição de task ECS
resource "aws_ecs_task_definition" "app_task" {
  family                   = "app-task"
  network_mode             = "awsvpc"
  requires_compatibilities = ["FARGATE"]

  container_definitions = jsonencode([
    {
      name  = "quickorder",
      image = "sua-imagem-docker-quickorder",
      portMappings = [
        {
          containerPort = 80,
          hostPort      = 80,
        },
      ],
      environment = [
        {
          name  = "DB_CONNECTION_STRING_POSTGRES",
          value = "postgres://${aws_db_instance.postgres_db.identifier}/${aws_db_instance.postgres_db.db_name}",
        },
        {
          name  = "DB_CONNECTION_STRING_MONGODB",
          value = "mongodb://${aws_db_instance.mongodb_db.identifier}/${aws_db_instance.mongodb_db.db_name}",
        },
      ],
    },
  ])
}