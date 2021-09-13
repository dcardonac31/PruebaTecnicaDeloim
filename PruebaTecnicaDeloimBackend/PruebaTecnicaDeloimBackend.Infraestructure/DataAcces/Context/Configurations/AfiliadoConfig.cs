﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class AfiliadoConfig : IEntityTypeConfiguration<Afiliado>
    {
        private readonly byte[] DefaultFoto = System.Text.Encoding.UTF8.GetBytes("data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/7QLCUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAqUcAVoAAxslRxwBAAACAAQcAgUAN2F2YXRhciBpY29uLCBwcm9maWxlIGljb24sIE1lbWJlciBMb2dpbiBWZWN0b3IgaXNvbGF0ZWQcAhkABGljb24cAhkABmF2YXRhchwCGQAHcHJvZmlsZRwCGQADYXBwHAIZAApiYWNrZ3JvdW5kHAIZAAhidXNpbmVzcxwCGQAGYnV0dG9uHAIZAA1jb21tdW5pY2F0aW9uHAIZAAhjb21wdXRlchwCGQAGZGVzaWduHAIZAARmYWNlHAIZAAZmZW1hbGUcAhkABGZsYXQcAhkABmZyaWVuZBwCGQAHZ3JhcGhpYxwCGQAFZ3JvdXAcAhkABGhlYWQcAhkABWh1bWFuHAIZAAxpbGx1c3RyYXRpb24cAhkACGludGVybmV0HAIZAARsaW5rHAIZAARtYWxlHAIZAANtYW4cAhkAB21hbmFnZXIcAhkABm1lbWJlchwCGQADbWVuHAIZAAdtZXNzYWdlHAIZAAZtb2JpbGUcAhkAB25ldHdvcmscAhkAA25ldxwCGQAGb2ZmaWNlHAIZAAZwZW9wbGUcAhkABnBlcnNvbhwCGQAIcGVyc29uYWwcAhkABXBob25lHAIZAANwaWMcAhkACXBpY3RvZ3JhbRwCGQAEc2lnbhwCGQAKc2lsaG91ZXR0ZRwCGQAGc2ltcGxlHAIZAAVzbWFydBwCGQAGc29jaWFsHAIZAAZzeW1ib2wcAhkABHRlYW0cAhkACnRlY2hub2xvZ3kcAhkABHVzZXIcAhkABnZlY3RvchwCGQADd2ViHAIZAAV3aGl0ZRwCGQAFd29tYW4cAngAKWF2YXRhciBpY29uIFZlY3RvciBmb3IgcHJvZmlsZSBwaG90byBzaWduHAIAAAIABAD/4QCYRXhpZgAATU0AKgAAAAgABgEOAAIAAAAqAAAAVgESAAMAAAABAAEAAAEaAAUAAAABAAAAgAEbAAUAAAABAAAAiAEoAAMAAAABAAEAAAITAAMAAAABAAEAAAAAAABhdmF0YXIgaWNvbiBWZWN0b3IgZm9yIHByb2ZpbGUgcGhvdG8gc2lnbgAAAABkAAAAAQAAAGQAAAAB/+ERwWh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8APD94cGFja2V0IGJlZ2luPSfvu78nIGlkPSdXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQnPz4NCjx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkltYWdlOjpFeGlmVG9vbCAxMS41MSI+DQoJPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4NCgkJPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIj4NCgkJCTxkYzpkZXNjcmlwdGlvbj4NCgkJCQk8cmRmOkFsdD4NCgkJCQkJPHJkZjpsaSB4bWw6bGFuZz0ieC1kZWZhdWx0Ij5hdmF0YXIgaWNvbiBWZWN0b3IgZm9yIHByb2ZpbGUgcGhvdG8gc2lnbjwvcmRmOmxpPg0KCQkJCTwvcmRmOkFsdD4NCgkJCTwvZGM6ZGVzY3JpcHRpb24+DQoJCQk8ZGM6c3ViamVjdD4NCgkJCQk8cmRmOkJhZz4NCgkJCQkJPHJkZjpsaT5pY29uPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+YXZhdGFyPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+cHJvZmlsZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmFwcDwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmJhY2tncm91bmQ8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5idXNpbmVzczwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmJ1dHRvbjwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmNvbW11bmljYXRpb248L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5jb21wdXRlcjwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmRlc2lnbjwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmZhY2U8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5mZW1hbGU8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5mbGF0PC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+ZnJpZW5kPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+Z3JhcGhpYzwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmdyb3VwPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+aGVhZDwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPmh1bWFuPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+aWxsdXN0cmF0aW9uPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+aW50ZXJuZXQ8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5saW5rPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+bWFsZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPm1hbjwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPm1hbmFnZXI8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5tZW1iZXI8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5tZW48L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5tZXNzYWdlPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+bW9iaWxlPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+bmV0d29yazwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPm5ldzwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPm9mZmljZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnBlb3BsZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnBlcnNvbjwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnBlcnNvbmFsPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+cGhvbmU8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5waWM8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5waWN0b2dyYW08L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT5zaWduPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+c2lsaG91ZXR0ZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnNpbXBsZTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnNtYXJ0PC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+c29jaWFsPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+c3ltYm9sPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+dGVhbTwvcmRmOmxpPg0KCQkJCQk8cmRmOmxpPnRlY2hub2xvZ3k8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT51c2VyPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+dmVjdG9yPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+d2ViPC9yZGY6bGk+DQoJCQkJCTxyZGY6bGk+d2hpdGU8L3JkZjpsaT4NCgkJCQkJPHJkZjpsaT53b21hbjwvcmRmOmxpPg0KCQkJCTwvcmRmOkJhZz4NCgkJCTwvZGM6c3ViamVjdD4NCgkJCTxkYzp0aXRsZT4NCgkJCQk8cmRmOkFsdD4NCgkJCQkJPHJkZjpsaSB4bWw6bGFuZz0ieC1kZWZhdWx0Ij5hdmF0YXIgaWNvbiwgcHJvZmlsZSBpY29uLCBNZW1iZXIgTG9naW4gVmVjdG9yIGlzb2xhdGVkPC9yZGY6bGk+DQoJCQkJPC9yZGY6QWx0Pg0KCQkJPC9kYzp0aXRsZT4NCgkJPC9yZGY6RGVzY3JpcHRpb24+DQoJPC9yZGY6UkRGPg0KPC94OnhtcG1ldGE+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDw/eHBhY2tldCBlbmQ9J3cnPz7/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCAEjASEDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACims+01Dqer2ui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V/CRvCPxX8L2+rx2yS/2Vq1uRb6toEsgAM1pcAExtlUYowaOQxqJEdRtr3iigD+VT/gpx/wanfHb9ja91DxH8L7e6+N3w8VjJG2kWpHiHTY8qAtxYDLTY37d9sZMiNneOEcD8tL60k0+8lgmjkhmhcpJG42tGwOCCOxB4r+/RkBH+FfNP7b3/BH79nP/AIKGNNd/FH4X6Fq3iCRNi+IbLfputKRGY4y13blJJVjByscxkjBA+Q9KAP4m6K/oE/ak/wCDI+1le7vfgn8apoVCD7NpHjfTRJlwrEl7+0CgKW2jAtCQCTkkYPw38Zf+DUr9tD4T386af8P9A8eWNuHZr7w74lsjGyqeNsV09vOxYchRFn1APFAH5v0V9NeMv+CM37WXga+W3vP2cPjNNIyht2n+E7zUY+f9u3jkUH2J4rHH/BJz9qZj/wAm1fH4dufh7q3/AMj0AfPtFfaXw1/4N4/20Pisq/2X+z/4utS0fmj+2Z7TRcL/ANvk0Xzf7J59q+s/2dv+DMT9on4i3lrcfELxl8OvhvpchAnjinm1rVIPuciGJUt2GC3/AC8g7kxjB3UAfj4i5Fez/sa/8E9/jJ/wUB8cf2B8I/AGveMLqF1S7ureIQ6dpuVZgbm7k2wQZVWKiRwWIwoZiBX9G/7IX/Box+zN+zgtnqnjpPEnxs8QQiNpF1q6Om6RHMjb/Njs7bDMpwFMU81whUn5T3/Tb4V/DbQfhL4NsfD/AIX8PaN4V8OaZH5NhpOk2UdjY2aElsRQRqqRjLE4CjJySASRQB+Tn/BJ7/g0r+HP7Kl5Y+M/j7daT8XfHFv+8g0GOFm8L6TIGUqxSUK99IADgzKkI8xgYXZUkr9h4kWOMKoVVUYAA4A9KUDil6UAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRjmiigAxRRRQAYooooACM0YoooACoJ6UUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAf/2Q==");

        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder.ToTable("Afiliado");

            builder.HasKey(e => new { e.AfiliadoID }).HasName("PK_Afiliado");

            builder.Property(e => e.AfiliadoID)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AfiliadoNombre)
                .IsRequired();

            builder.Property(e => e.LugarNacimiento)
                .IsRequired();

            builder.Property(e => e.Foto)
                .HasDefaultValue(DefaultFoto)
                .IsRequired();

            builder.Property(e => e.Peso)
                .HasDefaultValue(0)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
