# Configuração de um security group permitindo acesso ao aplicativo
resource "aws_security_group" "app_sg" {
  name        = "app_sg"
  description = "Security Group para a aplicação .NET no ECS"
  vpc_id      = data.aws_vpc.this.id

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