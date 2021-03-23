﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Drawing;

namespace Vortice
{
    public abstract partial class Application : IDisposable
    {
        private bool _paused;
        private bool _exitRequested;

        protected IGraphicsDevice? _graphicsDevice;
        public Window? MainWindow { get; private set; }

        protected Application()
        {
            PlatformConstruct();
        }

        public void Dispose()
        {
            _graphicsDevice?.Dispose();
        }

        protected virtual void InitializeBeforeRun()
        {
        }

        public void Tick()
        {
            _graphicsDevice!.DrawFrame(OnDraw);
        }

        public void Run()
        {
            PlatformRun();
        }

        protected virtual void OnActivated()
        {
        }

        protected virtual void OnDeactivated()
        {
        }

        protected virtual void OnDraw(int width, int height)
        {
        }
    }
}
