﻿using System;
using System.Collections.Generic;

namespace Claw.Audio
{
    /// <summary>
    /// Representa uma instância de <see cref="SoundEffect"/>.
    /// </summary>
    public sealed class SoundEffectInstance
    {
        public bool IsLooped = false;
        /// <summary>
        /// Volume do áudio (entre 0 e 1).
        /// </summary>
        public float Volume
        {
            get => _volume;
            set => _volume = Mathf.Clamp(value, 0, 1);
        }
        /// <summary>
        /// Duração do áudio, em segundos.
        /// </summary>
        public float Duration => audio.Duration;
        /// <summary>
        /// Momento em que o áudio está, em segundos.
        /// </summary>
        public float Current => AudioManager.CalculateDuration(audio.Length, audio.Channels);
        public readonly SoundEffectGroup Group;
        private float _volume = 1;
        internal long offset = 0;
        internal SoundEffect audio;

        public SoundEffectInstance(SoundEffect audio, SoundEffectGroup group)
        {
            this.audio = audio;
            Group = group;
        }

        /// <summary>
        /// Retorna um sample e finaliza o efeito sonoro, se preciso.
        /// </summary>
        /// <param name="index">Index do efeito sonoro.</param>
        /// <param name="list">Lista em que o efeito sonoro está.</param>
        internal float GetSample(out bool finished)
        {
            finished = false;

            if (offset >= audio.Length)
            {
                offset = 0;
                finished = true;
            }

            float value = audio.GetSample(offset);
            offset++;

            return value;
        }
    }
}