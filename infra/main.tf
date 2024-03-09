provider "aws" {
  region = "us-east-1"
}

# Criação de um cluster ECS
resource "aws_ecs_cluster" "app_cluster" {
  name = "app-cluster"
}

# Criação de uma definição de task ECS
resource "aws_ecs_task_definition" "app_task" {
  family                   = "app-task"
  network_mode             = "awsvpc"
  requires_compatibilities = ["FARGATE"]

  container_definitions = jsonencode([
    {
      name  = "quickorder",
      image = "590183827841.dkr.ecr.us-east-1.amazonaws.com/quickorder:latest",
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

# Criação de um serviço ECS
resource "aws_ecs_service" "app_service" {
  name            = "app-service"
  cluster         = aws_ecs_cluster.app_cluster.id
  task_definition = aws_ecs_task_definition.app_task.arn
  launch_type     = "FARGATE"

  network_configuration {
    subnets         = ["sua-subnet-1", "sua-subnet-2"] # Substitua pelos IDs das suas subnets
    security_groups = ["${aws_security_group.app_sg.id}"]
  }
}

# Configuração de um security group permitindo acesso ao aplicativo
resource "aws_security_group" "app_sg" {
  name        = "app_sg"
  description = "Security Group para a aplicação .NET no ECS"

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# Criação de uma instância de banco de dados PostgreSQL
resource "aws_db_instance" "postgres_db" {
  identifier           = "db-postgres"
  allocated_storage    = 20
  storage_type         = "gp2"
  engine               = "postgres"
  engine_version       = "latest"
  instance_class       = "db.t2.micro"
  db_name              = "postgres"
  username             = "postgres"
  password             = "postgres"
  parameter_group_name = "default.postgres11"
  publicly_accessible  = false
  skip_final_snapshot  = true
}

# Criação de uma instância de banco de dados MongoDB
resource "aws_db_instance" "mongodb_db" {
  identifier           = "db-mongodb"
  allocated_storage    = 20
  storage_type         = "gp2"
  engine               = "mongodb"
  engine_version       = "4.0"
  instance_class       = "db.t2.micro"
  db_name              = "mongodb"
  username             = "mongo"
  password             = "mongo"
  parameter_group_name = "default.mongodb4.0"
  publicly_accessible  = false
  skip_final_snapshot  = true
}
