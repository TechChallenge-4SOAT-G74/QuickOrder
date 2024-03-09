
# Criação de uma instância de banco de dados MongoDB
resource "aws_db_instance" "mongodb_db" {
  identifier                   = "nome-do-banco-mongodb"
  allocated_storage            = 20
  storage_type                 = "gp2"
  engine                       = "mongodb"
  engine_version               = "4.0"
  instance_class               = "db.t2.micro"
  username                     = "usuario"
  password                     = "senha"
  parameter_group_name         = "default.mongodb4.0"
  publicly_accessible          = false
  skip_final_snapshot          = true
  max_allocated_storage        = var.maxStorage
  multi_az                     = false
  vpc_security_group_ids       = ["${aws_security_group.sg-mongodb_db.id}"]
  db_subnet_group_name         = aws_db_subnet_group.subnet-mongodb_db.id
  apply_immediately            = true
  deletion_protection          = true
  performance_insights_enabled = true
  backup_retention_period      = 1
  backup_window                = "00:00-00:30"
  copy_tags_to_snapshot        = true
  delete_automated_backups     = false
    db_name = var.mongoDbName
}
