# Criação de um cluster ECS
resource "aws_ecs_cluster" "app_cluster" {
  name = "app-cluster"
}