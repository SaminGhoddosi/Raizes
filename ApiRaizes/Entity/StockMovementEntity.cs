﻿namespace ApiRaizes.Entity
{
    public class StockMovementEntity
    {
        public enum MovementType2
        {
            Venda,
            Transferencia,
            Ajuste
        }
        public int Id { get; set; }
        public int ArmazenamentoId { get; set; }
        public MovementType2 TipoMovimento { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Observacoes { get; set; }
    }
}