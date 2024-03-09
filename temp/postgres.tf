# Criação de uma instância de banco de dados PostgreSQL
resource "aws_db_instance" "postgres_db" {
  identifier                   = "nome-do-banco-postgres"
  allocated_storage            = 20
  storage_type                 = "gp2"
  engine                       = "postgres"
  engine_version               = "latest"
  instance_class               = "db.t2.micro"
  username                     = "usuario"
  password                     = "senha"
  parameter_group_name         = "default.postgres11"
  publicly_accessible          = false
  skip_final_snapshot          = true
  max_allocated_storage        = var.maxStorage
  multi_az                     = false
  vpc_security_group_ids       = ["${aws_security_group.sg-rds.id}"]
  db_subnet_group_name         = aws_db_subnet_group.subnet-rds.id
  apply_immediately            = true
  deletion_protection          = true
  performance_insights_enabled = true
  backup_retention_period      = 1
  backup_window                = "00:00-00:30"
  copy_tags_to_snapshot        = true
  delete_automated_backups     = false
  db_name = var.postgresDbName
}