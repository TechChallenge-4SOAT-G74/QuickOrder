terraform {
  backend "s3" {
    bucket = "nomeBucket"
    key    = application / terraform.tfstate
    region = var.regionDefault
  }
}

provider "aws" {
  region = var.regionDefault
}